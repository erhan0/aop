using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.AroundAdvising
{
    public class AroundMethodWeaver: AroundWeaverBase
    {
        private MethodDefinition _ccMethod;

        public AroundMethodWeaver(MethodDefinition targetMethod, AroundAdvice advice, int priority): base(targetMethod, advice, priority)
        {
            
        }

        protected override string GetAdviceTypeName()
        {
            return "Around Method";
        }

        protected override Type GetJoinPointType()
        {
            return typeof (MethodJointPoint);
        }

        protected override void DefineMembers()
        {
            base.DefineMembers();
            _ccMethod = new MethodDefinition(JpName + "$TargetMethod", Method.Attributes, Method.ReturnType) { IsPrivate = true };

            Method.GenericParameters.TransferItemsTo(_ccMethod.GenericParameters);
            foreach (var p in _ccMethod.GenericParameters)
            {
                p.GetType().GetField("owner", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(p, _ccMethod);
                Method.GenericParameters.Add(new GenericParameter(p.Name, Method));
            }
        }

        /// <summary>
        /// To be appended on the static constructor, initializing static StaticJp field
        /// Already suppied as the first 2 arguments: AdviceInvoker, AdviceCallback
        /// </summary>
        /// <param name="il">IL processor of the static constructor</param>
        protected override void AppendInitializeStaticJp(ILProcessor il)
        {
            AppendCreateJpStaticPart(il);
        }

        protected virtual void AppendCreateJpStaticPart(ILProcessor il)
        {
            il.Append(OpCodes.Call, Module.ImportMethod<JointPointBase.StaticPart>("ForMethod"));
        }

        protected override void CallbackMethodBody(ILProcessor il, ParameterDefinition thisInstance, ParameterDefinition target, ParameterDefinition args)
        {
            if (!_ccMethod.IsStatic)
                il.Append(OpCodes.Ldarg, thisInstance);
            for(var i=0; i<_ccMethod.Parameters.Count; i++)
            {
                il.Append(OpCodes.Ldarg, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldelem_Ref);
                var type = _ccMethod.Parameters[i].ParameterType;
                if (type.IsValueType)
                    il.Append(OpCodes.Unbox_Any, type);
            }

            il.Append(OpCodes.Call, _ccMethod.MakeHostInstanceGeneric(JpThisGenericParams).MakeGenerics(JpMethodGenericParams));
            if (_ccMethod.ReturnsVoid())
                il.Append(OpCodes.Ldnull);
            else if (_ccMethod.ReturnType.IsValueType)
                il.Append(OpCodes.Box, _ccMethod.ReturnType);
            il.Append(OpCodes.Ret);
        }

        protected override void WeaveOriginalTarget()
        {
            Method.Body.Instructions.TransferItemsTo(_ccMethod.Body.Instructions);
            Method.Body.Variables.TransferItemsTo(_ccMethod.Body.Variables);
            Method.Body.ExceptionHandlers.TransferItemsTo(_ccMethod.Body.ExceptionHandlers);
            
            var args = Method.AddLocal(typeof (object[]));

            var il = Method.Body.GetILProcessor();
            il.Append(OpCodes.Nop);
            il.Append(OpCodes.Ldc_I4, Method.Parameters.Count);
            il.Append(OpCodes.Newarr, Module.Import(typeof(object)));
            il.Append(OpCodes.Stloc, args);

            var targetParams = Method.Parameters.ToArray();
            foreach(var p in targetParams)
            {
                _ccMethod.Parameters.Add(p);
            
                il.Append(OpCodes.Ldloc, args);
                il.Append(OpCodes.Ldc_I4, p.Index);
                il.Append(OpCodes.Ldarg, p);
                if (p.ParameterType.IsValueType)
                    il.Append(OpCodes.Box, p.ParameterType);
                il.Append(OpCodes.Stelem_Ref);
            }

            _ccMethod.Body.InitLocals = Method.Body.InitLocals;
            Method.DeclaringType.Methods.Add(_ccMethod);

            il.Append(OpCodes.Ldnull); // target
            LdThis(il);
            AppendCallDispatch(il, args, GetRefThisToJpStatic());

            if (Method.ReturnsVoid())
                il.Append(OpCodes.Pop);
            else if (Method.ReturnType.IsValueType)
                il.Append(OpCodes.Unbox_Any, Method.ReturnType);
            il.Append(OpCodes.Ret);
        }
    }
}
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
        private MethodDefinition ccMethod;

        public AroundMethodWeaver(MethodDefinition targetMethod, AroundAdvice advice, int priority): base(targetMethod, advice, priority)
        {
            
        }

        protected override string AdviceTypeName { get { return "Around Method"; } }

        protected override Type JoinPointType { get { return typeof(MethodJointPoint); } }

        protected override void DefineMembers()
        {
            base.DefineMembers();
            ccMethod = new MethodDefinition(jpName + "$TargetMethod", method.Attributes, method.ReturnType) { IsPrivate = true };

            method.GenericParameters.TransferItemsTo(ccMethod.GenericParameters);
            foreach (var p in ccMethod.GenericParameters)
            {
                p.GetType().GetField("owner", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(p, ccMethod);
                method.GenericParameters.Add(new GenericParameter(p.Name, method));
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
            if (!ccMethod.IsStatic)
            {
                il.Append(OpCodes.Ldarg, thisInstance);
            }

            for (var i=0; i<ccMethod.Parameters.Count; i++)
            {
                il.Append(OpCodes.Ldarg, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldelem_Ref);
                var type = ccMethod.Parameters[i].ParameterType;
                if (type.IsValueType)
                {
                    il.Append(OpCodes.Unbox_Any, type);
                }
            }

            il.Append(OpCodes.Call, ccMethod.MakeHostInstanceGeneric(JpThisGenericParams).MakeGenerics(JpMethodGenericParams));
            if (ccMethod.ReturnsVoid())
            {
                il.Append(OpCodes.Ldnull);
            }
            else if (ccMethod.ReturnType.IsValueType)
            {
                il.Append(OpCodes.Box, ccMethod.ReturnType);
            }

            il.Append(OpCodes.Ret);
        }

        protected override void WeaveOriginalTarget()
        {
            method.Body.Instructions.TransferItemsTo(ccMethod.Body.Instructions);
            method.Body.Variables.TransferItemsTo(ccMethod.Body.Variables);
            method.Body.ExceptionHandlers.TransferItemsTo(ccMethod.Body.ExceptionHandlers);
            
            var args = method.AddLocal(typeof (object[]));

            var il = method.Body.GetILProcessor();
            il.Append(OpCodes.Nop);
            il.Append(OpCodes.Ldc_I4, method.Parameters.Count);
            il.Append(OpCodes.Newarr, Module.Import(typeof(object)));
            il.Append(OpCodes.Stloc, args);

            var targetParams = method.Parameters.ToArray();
            foreach(var p in targetParams)
            {
                ccMethod.Parameters.Add(p);
            
                il.Append(OpCodes.Ldloc, args);
                il.Append(OpCodes.Ldc_I4, p.Index);
                il.Append(OpCodes.Ldarg, p);
                if (p.ParameterType.IsValueType)
                {
                    il.Append(OpCodes.Box, p.ParameterType);
                }

                il.Append(OpCodes.Stelem_Ref);
            }

            ccMethod.Body.InitLocals = method.Body.InitLocals;
            method.DeclaringType.Methods.Add(ccMethod);

            il.Append(OpCodes.Ldnull); // target
            LdThis(il);
            AppendCallDispatch(il, args, GetRefThisToJpStatic());

            if (method.ReturnsVoid())
            {
                il.Append(OpCodes.Pop);
            }
            else if (method.ReturnType.IsValueType)
            {
                il.Append(OpCodes.Unbox_Any, method.ReturnType);
            }

            il.Append(OpCodes.Ret);
        }
    }
}
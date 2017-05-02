using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using ParameterAttributes = Mono.Cecil.ParameterAttributes;
using TypeAttributes = Mono.Cecil.TypeAttributes;

namespace SheepAspect.AroundAdvising
{
    public abstract class AroundWeaverBase : MethodWeaverBase
    {
        protected MethodReference AdviceMethod;
        protected TypeReference AspectType;
        private readonly string _adviceName;
        protected MethodDefinition InvokerMethod;
        private FieldDefinition _jpStatic;
        protected string JpName;
        protected MethodDefinition CallbackMethod;
        private bool _createInvoker;
        protected TypeDefinition JpStaticClass;

        protected AroundWeaverBase(MethodDefinition method, AroundAdvice advice, int priority): base(method)
        {
            _adviceName = advice.GetFullName();
            _priority = priority;

            AdviceMethod = Module.Import(advice.AdviceMethod);
            AspectType = Module.Import(advice.AdviceMethod.ReflectedType);
            Method = method;
        }

        public override void Weave()
        {
            Init();
            ValidateAdvice();
            DefineMembers();

            AdviceInvokerMethod();
            WeaveOriginalTarget();
            MakeCallbackMethod(); 
            InitStaticJp();
        }

        protected virtual void Init()
        {
        }

        protected virtual void DefineMembers()
        {
            DefineJpStatic();

            CallbackMethod = new MethodDefinition("Callback", MethodAttributes.Static | MethodAttributes.Private,
                                                  Module.Import(typeof(object)));
            JpStaticClass.Methods.Add(CallbackMethod);

            var invokerName = "<>sac_" + _adviceName + "$Invoke";
            InvokerMethod = Method.DeclaringType.Methods.FirstOrDefault(m => m.Name.Equals(invokerName));
            if (InvokerMethod == null)
            {
                InvokerMethod = new MethodDefinition(invokerName, MethodAttributes.Static | MethodAttributes.Private,
                                                      Module.Import(typeof(object)));
                Method.DeclaringType.Methods.Add(InvokerMethod);
                _createInvoker = true;
            }
        }

        private void DefineJpStatic()
        {
            var baseJpName = "<>sac_" + Method.Name;
            JpName = baseJpName;
            for (var i = 0; Method.DeclaringType.NestedTypes.Any(x=> x.Name.Equals(JpName+"<>JpStatic")); i++ )
                JpName = baseJpName + i;

            _jpStatic = new FieldDefinition("Instance", FieldAttributes.Static | FieldAttributes.Public, Module.Import(typeof(JointPointBase.StaticPart)));
            JpStaticClass = new TypeDefinition("",
                                                JpName+"<>JpStatic",
                                                TypeAttributes.NestedPrivate | TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.BeforeFieldInit
                                                , Module.Import(typeof(object)))
                                 {
                                     Fields = {_jpStatic}
                                 };
            JpThisGenericParams = Method.DeclaringType.GenericParameters.Select(AddGenericParamToJp).ToArray();
            JpMethodGenericParams = Method.GenericParameters.Select(AddGenericParamToJp).ToArray();

            Method.DeclaringType.NestedTypes.Add(JpStaticClass);
        }

        protected readonly IDictionary<GenericParameter, GenericParameter> JpGenericParamMap = new Dictionary<GenericParameter, GenericParameter>();
        protected GenericParameter[] JpThisGenericParams;
        protected GenericParameter[] JpMethodGenericParams;
        private int _priority = 100;

        private GenericParameter AddGenericParamToJp(GenericParameter param)
        {
            var clone = new GenericParameter(param.Name, JpStaticClass);
            JpStaticClass.GenericParameters.Add(clone);
            JpGenericParamMap[param] = clone;
            return clone;
        }

        /// <summary>
        /// Weavers with lower priority values will get processed earlier during compilation
        /// This is useful to ensure certain weavers only get executed after all others, hence ensuring it will not get overruled by accident
        /// By default: 100
        /// </summary>
        public override int Priority
        {
            get { return _priority; }
        }

        protected void ValidateAdvice()
        {
            var jpType = AdviceMethod.Module.Import(GetJoinPointType()).Resolve();
            if (AdviceMethod.Parameters.Count != 1)
                throw new InvalidAdviceSignatureException(AdviceMethod, GetAdviceTypeName(), "Should have exactly one method argument of type assignable to {0}".FormatWith(jpType));

            if (!AdviceMethod.Parameters[0].ParameterType.Resolve().IsAssignableFrom(jpType))
                throw new InvalidAdviceSignatureException(AdviceMethod, GetAdviceTypeName(),
                                                          "Parameter type should be assignable to {0}".FormatWith(
                                                              jpType.Name));
        }

        protected abstract string GetAdviceTypeName();
        protected abstract Type GetJoinPointType();

        /// <summary>
        /// Requires 2 items (object target, object this) in the evaulation stack
        /// </summary>
        /// <param name="il">IlProcessor, usually that of the target-method</param>
        /// <param name="args">Args variable for dispatching</param>
        /// <param name="jpStaticRef"></param>
        protected void AppendCallDispatch(ILProcessor il, VariableDefinition args, GenericInstanceType jpStaticRef)
        {
            il.Append(OpCodes.Ldsfld, new FieldReference(_jpStatic.Name, _jpStatic.FieldType, jpStaticRef));
            il.Append(OpCodes.Ldloc, args);
            var dispatchMethod = new GenericInstanceMethod(Module.ImportMethod(typeof(AspectRuntime), "Dispatch"))
                                     {
                                         GenericArguments = { AspectType }
                                     };
            il.Append(OpCodes.Call, dispatchMethod);
        }

        protected GenericInstanceType GetRefThisToJpStatic()
        {
            var staticJpRef = new GenericInstanceType(JpStaticClass);
            foreach (var p in Method.DeclaringType.GenericParameters)
                staticJpRef.GenericArguments.Add(p);
            foreach (var p in Method.GenericParameters)
                staticJpRef.GenericArguments.Add(p);
            return staticJpRef;
        }

        protected void MakeCallbackMethod()
        {
            var thisInstance = new ParameterDefinition("thisInstance", ParameterAttributes.None, Module.Import(typeof (object)));
            var target = new ParameterDefinition("target", ParameterAttributes.None, Module.Import(typeof (object)));
            var args = new ParameterDefinition("args", ParameterAttributes.None, Module.Import(typeof(object[])));

            CallbackMethod.Parameters.Add(thisInstance);
            CallbackMethod.Parameters.Add(target);
            CallbackMethod.Parameters.Add(args);

            CallbackMethodBody(CallbackMethod.Body.GetILProcessor(), thisInstance, target, args);
        }

        protected abstract void CallbackMethodBody(ILProcessor il, ParameterDefinition thisInstance, ParameterDefinition target, ParameterDefinition args);

        protected void AdviceInvokerMethod()
        {
            if (_createInvoker)
            {
                var aspectParam = new ParameterDefinition("aspect", ParameterAttributes.None,
                                                          Module.Import(typeof(object)));
                var jpParam = new ParameterDefinition("joinPoint", ParameterAttributes.None,
                                                      Method.Module.Import(
                                                          Module.Import(typeof(IJointPoint))));

                InvokerMethod.Parameters.Add(aspectParam);
                InvokerMethod.Parameters.Add(jpParam);

                var il = InvokerMethod.Body.GetILProcessor();
                il.Append(OpCodes.Ldarg, aspectParam);
                il.Append(OpCodes.Ldarg, jpParam);
                il.Append(OpCodes.Call, AdviceMethod);
                if (AdviceMethod.ReturnsVoid())
                    il.Append(OpCodes.Ldnull);
                else if (AdviceMethod.ReturnType.IsValueType)
                    il.Append(OpCodes.Box, AdviceMethod.ReturnType);
                il.Append(OpCodes.Ret);

            }
        }

        protected void InitStaticJp()
        {
            var cons = JpStaticClass.CreateStaticConstructor();
            var il = cons.Body.GetILProcessor();

            var thisRef = Method.DeclaringType.MakeGenerics(JpThisGenericParams);
            
            il.Append(OpCodes.Ldnull);
            il.Append(OpCodes.Ldftn, InvokerMethod.MakeHostInstanceGeneric(thisRef));
            il.Append(OpCodes.Newobj, Module.Import(typeof(AdviceInvoker).GetConstructors()[0]));

            il.Append(OpCodes.Ldnull);
            il.Append(OpCodes.Ldftn, CallbackMethod.MakeHostGenericSelf());
            il.Append(OpCodes.Newobj, Module.Import(typeof(AdviceCallback).GetConstructors()[0]));

            il.Append(OpCodes.Ldtoken, Method.MakeGenerics(JpMethodGenericParams));
            il.Append(OpCodes.Ldtoken, thisRef);
            il.Append(OpCodes.Call,
                     Method.Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle)));

            AppendInitializeStaticJp(il);

            il.Append(OpCodes.Stsfld, _jpStatic.MakeHostGenericSelf());
            il.Append(OpCodes.Ret);
        }

        protected abstract void WeaveOriginalTarget();

        /// <summary>
        /// To be appended on the static constructor, initializing static StaticJp field
        /// Already suppied as the first 2 arguments: AdviceInvoker, AdviceCallback
        /// </summary>
        /// <param name="il">IL processor of the static constructor</param>
        protected abstract void AppendInitializeStaticJp(ILProcessor il);
    }
}
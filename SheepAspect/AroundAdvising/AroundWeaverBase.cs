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
        protected MethodReference adviceMethod;
        protected TypeReference aspectType;
        private readonly string adviceName;
        protected MethodDefinition invokerMethod;
        private FieldDefinition jpStatic;
        protected string jpName;
        protected MethodDefinition callbackMethod;
        private bool createInvoker;
        protected TypeDefinition jpStaticClass;

        protected AroundWeaverBase(MethodDefinition method, AroundAdvice advice, int priority): base(method)
        {
            adviceName = advice.FullName;
            _priority = priority;

            adviceMethod = Module.Import(advice.AdviceMethod);
            aspectType = Module.Import(advice.AdviceMethod.ReflectedType);
            base.method = method;
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

            callbackMethod = new MethodDefinition("Callback", MethodAttributes.Static | MethodAttributes.Private,
                                                  Module.Import(typeof(object)));
            jpStaticClass.Methods.Add(callbackMethod);

            var invokerName = "<>sac_" + adviceName + "$Invoke";
            invokerMethod = method.DeclaringType.Methods.FirstOrDefault(m => m.Name.Equals(invokerName));
            if (invokerMethod == null)
            {
                invokerMethod = new MethodDefinition(invokerName, MethodAttributes.Static | MethodAttributes.Private,
                                                      Module.Import(typeof(object)));
                method.DeclaringType.Methods.Add(invokerMethod);
                createInvoker = true;
            }
        }

        private void DefineJpStatic()
        {
            var baseJpName = "<>sac_" + method.Name;
            jpName = baseJpName;
            for (var i = 0; method.DeclaringType.NestedTypes.Any(x=> x.Name.Equals(jpName+"<>JpStatic")); i++ )
            {
                jpName = baseJpName + i;
            }

            jpStatic = new FieldDefinition("Instance", FieldAttributes.Static | FieldAttributes.Public, Module.Import(typeof(JointPointBase.StaticPart)));
            jpStaticClass = new TypeDefinition("",
                                                jpName+"<>JpStatic",
                                                TypeAttributes.NestedPrivate | TypeAttributes.Sealed | TypeAttributes.Abstract | TypeAttributes.BeforeFieldInit
                                                , Module.Import(typeof(object)))
                                 {
                                     Fields = {jpStatic}
                                 };
            JpThisGenericParams = method.DeclaringType.GenericParameters.Select(AddGenericParamToJp).ToArray();
            JpMethodGenericParams = method.GenericParameters.Select(AddGenericParamToJp).ToArray();

            method.DeclaringType.NestedTypes.Add(jpStaticClass);
        }

        protected readonly IDictionary<GenericParameter, GenericParameter> JpGenericParamMap = new Dictionary<GenericParameter, GenericParameter>();
        protected GenericParameter[] JpThisGenericParams;
        protected GenericParameter[] JpMethodGenericParams;
        private int _priority = 100;

        private GenericParameter AddGenericParamToJp(GenericParameter param)
        {
            var clone = new GenericParameter(param.Name, jpStaticClass);
            jpStaticClass.GenericParameters.Add(clone);
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
            var jpType = adviceMethod.Module.Import(JoinPointType).Resolve();
            if (adviceMethod.Parameters.Count != 1)
            {
                throw new InvalidAdviceSignatureException(adviceMethod, AdviceTypeName, "Should have exactly one method argument of type assignable to {0}".FormatWith(jpType));
            }

            if (!adviceMethod.Parameters[0].ParameterType.Resolve().IsAssignableFrom(jpType))
            {
                throw new InvalidAdviceSignatureException(adviceMethod, AdviceTypeName,
                                                          "Parameter type should be assignable to {0}".FormatWith(
                                                              jpType.Name));
            }
        }

        protected abstract string AdviceTypeName { get; }
        protected abstract Type JoinPointType { get; }

        /// <summary>
        /// Requires 2 items (object target, object this) in the evaulation stack
        /// </summary>
        /// <param name="il">IlProcessor, usually that of the target-method</param>
        /// <param name="args">Args variable for dispatching</param>
        /// <param name="jpStaticRef"></param>
        protected void AppendCallDispatch(ILProcessor il, VariableDefinition args, GenericInstanceType jpStaticRef)
        {
            il.Append(OpCodes.Ldsfld, new FieldReference(jpStatic.Name, jpStatic.FieldType, jpStaticRef));
            il.Append(OpCodes.Ldloc, args);
            var dispatchMethod = new GenericInstanceMethod(Module.ImportMethod(typeof(AspectRuntime), "Dispatch"))
                                     {
                                         GenericArguments = { aspectType }
                                     };
            il.Append(OpCodes.Call, dispatchMethod);
        }

        protected GenericInstanceType GetRefThisToJpStatic()
        {
            var staticJpRef = new GenericInstanceType(jpStaticClass);
            foreach (var p in method.DeclaringType.GenericParameters)
            {
                staticJpRef.GenericArguments.Add(p);
            }

            foreach (var p in method.GenericParameters)
            {
                staticJpRef.GenericArguments.Add(p);
            }

            return staticJpRef;
        }

        protected void MakeCallbackMethod()
        {
            var thisInstance = new ParameterDefinition("thisInstance", ParameterAttributes.None, Module.Import(typeof (object)));
            var target = new ParameterDefinition("target", ParameterAttributes.None, Module.Import(typeof (object)));
            var args = new ParameterDefinition("args", ParameterAttributes.None, Module.Import(typeof(object[])));

            callbackMethod.Parameters.Add(thisInstance);
            callbackMethod.Parameters.Add(target);
            callbackMethod.Parameters.Add(args);

            CallbackMethodBody(callbackMethod.Body.GetILProcessor(), thisInstance, target, args);
        }

        protected abstract void CallbackMethodBody(ILProcessor il, ParameterDefinition thisInstance, ParameterDefinition target, ParameterDefinition args);

        protected void AdviceInvokerMethod()
        {
            if (createInvoker)
            {
                var aspectParam = new ParameterDefinition("aspect", ParameterAttributes.None,
                                                          Module.Import(typeof(object)));
                var jpParam = new ParameterDefinition("joinPoint", ParameterAttributes.None,
                                                      method.Module.Import(
                                                          Module.Import(typeof(IJointPoint))));

                invokerMethod.Parameters.Add(aspectParam);
                invokerMethod.Parameters.Add(jpParam);

                var il = invokerMethod.Body.GetILProcessor();
                il.Append(OpCodes.Ldarg, aspectParam);
                il.Append(OpCodes.Ldarg, jpParam);
                il.Append(OpCodes.Call, adviceMethod);
                if (adviceMethod.ReturnsVoid())
                {
                    il.Append(OpCodes.Ldnull);
                }
                else if (adviceMethod.ReturnType.IsValueType)
                {
                    il.Append(OpCodes.Box, adviceMethod.ReturnType);
                }

                il.Append(OpCodes.Ret);

            }
        }

        protected void InitStaticJp()
        {
            var cons = jpStaticClass.CreateStaticConstructor();
            var il = cons.Body.GetILProcessor();

            var thisRef = method.DeclaringType.MakeGenerics(JpThisGenericParams);
            
            il.Append(OpCodes.Ldnull);
            il.Append(OpCodes.Ldftn, invokerMethod.MakeHostInstanceGeneric(thisRef));
            il.Append(OpCodes.Newobj, Module.Import(typeof(AdviceInvoker).GetConstructors()[0]));

            il.Append(OpCodes.Ldnull);
            il.Append(OpCodes.Ldftn, callbackMethod.MakeHostGenericSelf());
            il.Append(OpCodes.Newobj, Module.Import(typeof(AdviceCallback).GetConstructors()[0]));

            il.Append(OpCodes.Ldtoken, method.MakeGenerics(JpMethodGenericParams));
            il.Append(OpCodes.Ldtoken, thisRef);
            il.Append(OpCodes.Call,
                     method.Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle)));

            AppendInitializeStaticJp(il);

            il.Append(OpCodes.Stsfld, jpStatic.MakeHostGenericSelf());
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
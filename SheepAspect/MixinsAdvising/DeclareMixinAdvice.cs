using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using System.Linq;
using SheepAspect.Helpers.CecilExtensions;
using FieldAttributes = Mono.Cecil.FieldAttributes;
using Mono.Cecil.Rocks;

namespace SheepAspect.MixinsAdvising
{
    public abstract class DeclareMixinAdvice: AdviceBase
    {
        public const int PRIORITY = 90;

        public Type[] AdditionalInterfaces { get; private set; }
        public bool AsFactory { get; set; }

        public Type MainInterface { get; set; }

        public Type AspectType { get; set; }

        public int Priority { get { return PRIORITY; } }

        protected DeclareMixinAdvice(IEnumerable<IPointcut> pointcuts, MemberInfo memberInfo, Type mainInterface, Type[] additionalInterfaces, bool asFactory) : base(pointcuts)
        {
            MainInterface = mainInterface;
            AdditionalInterfaces = additionalInterfaces;
            AsFactory = asFactory;
            AspectType = memberInfo.ReflectedType;

            _fullName = string.Format("MixAsInterface/{0}::{1}", memberInfo.ReflectedType.FullName, memberInfo.Name);
        }

        private readonly string _fullName;

        public override string GetFullName()
        {
            return _fullName;
        }
    }

    public abstract class DeclareMixinsWeaver : IWeaver
    {
        protected readonly TypeDefinition WeavedType;
        private readonly DeclareMixinAdvice _advice;
        protected readonly TypeReference _aspectType;
        private FieldDefinition _implStoreField;
        private readonly TypeReference[] _interfaces;
        private MethodDefinition _factoryDelegate;
        protected readonly TypeReference _mainInterface;

        protected DeclareMixinsWeaver(TypeDefinition weavedType, DeclareMixinAdvice advice)
        {
            WeavedType = weavedType;
            _advice = advice;
            _mainInterface = Module.Import(advice.MainInterface);
            _aspectType = Module.Import(advice.AspectType);

            IEnumerable<TypeReference> interfaces = new[] {_mainInterface};
            if (_advice.AdditionalInterfaces != null)
                interfaces = interfaces.Union(_advice.AdditionalInterfaces.Select(x => WeavedType.Module.Import(x)));
            _interfaces = interfaces.ToArray();
        }

        public int Priority
        {
            get { return _advice.Priority; }
        }

        public void Weave()
        {
            Validate();

            var storeType = Module.Import(
                _advice.AsFactory ? typeof(CachedMixinsImplementationBinding<,>) : typeof(MixinsImplementationBinding<,>))
                .MakeGenerics(_aspectType, _mainInterface);

            WeavedType.Fields.Add(_implStoreField = new FieldDefinition("<>sac_implStore_" + _advice.GetFullName(), FieldAttributes.Private, storeType));

            CreateFactoryDelegate();
            InitLazyImplField();

            foreach (var interfaceRef in _interfaces)
            {
                var interfaceDef = interfaceRef.Resolve();
                
                if(WeavedType.Interfaces.Contains(interfaceRef))
                    throw new InterfaceAlreadyImplementedException(WeavedType, interfaceRef);

                WeavedType.Interfaces.Add(interfaceRef);
                var overridenMethods = interfaceDef.Methods.ToDictionary(x => x, OverrideMethod);
                
                foreach(var property in interfaceDef.Properties)
                {
                    WeavedType.Properties.Add(new PropertyDefinition(property.Name, property.Attributes, property.PropertyType)
                                             {
                                                 GetMethod = overridenMethods[property.GetMethod],
                                                 SetMethod = overridenMethods[property.SetMethod]
                                             });
                }

                foreach(var e in interfaceDef.Events)
                {
                    WeavedType.Events.Add(new EventDefinition(e.Name, e.Attributes, e.EventType)
                                         {
                                             AddMethod = overridenMethods[e.AddMethod],
                                             RemoveMethod = overridenMethods[e.InvokeMethod],
                                             InvokeMethod = overridenMethods[e.InvokeMethod]
                                         });
                }
            }
        }

        private void CreateFactoryDelegate()
        {
            WeavedType.Methods.Add(_factoryDelegate = new MethodDefinition("<>sac_getImpl_" + _advice.GetFullName(), MethodAttributes.Private, _mainInterface));
            _factoryDelegate.Parameters.Add(new ParameterDefinition(_aspectType));
            WriteFactoryDelegateBody(_factoryDelegate);
        }

        protected abstract void WriteFactoryDelegateBody(MethodDefinition il);

        private void InitLazyImplField()
        {
            var storeConstructor = _implStoreField.FieldType.SelectGenericSafeMethods(t=> t.GetConstructors()).First();
            var funcConstructor =
                WeavedType.Module.Import(typeof(Func<,>)).MakeGenericInstanceType(_factoryDelegate.Parameters[0].ParameterType, _factoryDelegate.ReturnType)
                .SelectGenericSafeMethods(t => t.GetConstructors()).First();
                
            foreach (var con in WeavedType.GetOrAddConstructors())
            {
                var il = con.Body.GetILProcessor();

                var i = 0;
                Action<Instruction> insertIl = instruction=> il.Body.Instructions.Insert(i++, instruction);

                insertIl(il.Create(OpCodes.Ldarg_0));

                //conIl.Body.Instructions.Insert(i++, conIl.Create(OpCodes.Ldnull));
                insertIl(il.Create(OpCodes.Ldtoken, con));
                insertIl(il.Create(OpCodes.Ldtoken, WeavedType));
                insertIl(il.Create(OpCodes.Call,
                     Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle))));
                
                insertIl(il.Create(OpCodes.Ldarg_0));

                var argArr = con.AddLocal(typeof (object[]));

                insertIl(il.Create(OpCodes.Ldc_I4, con.Parameters.Count));
                insertIl(il.Create(OpCodes.Newarr, Module.Import(typeof(object))));
                insertIl(il.Create(OpCodes.Stloc, argArr));

                foreach (var param in con.Parameters)
                {
                    insertIl(il.Create(OpCodes.Ldloc, argArr));
                    insertIl(il.Create(OpCodes.Ldc_I4, param.Index));
                    insertIl(il.Create(OpCodes.Ldarg, param));
                    if (param.ParameterType.IsValueType)
                        insertIl(il.Create(OpCodes.Box, param.ParameterType));
                    insertIl(il.Create(OpCodes.Stelem_Ref));
                }
                insertIl(il.Create(OpCodes.Ldloc, argArr));
                    
                insertIl(il.Create(OpCodes.Ldarg_0));

                insertIl(il.Create(OpCodes.Ldftn, _factoryDelegate));
                insertIl(il.Create(OpCodes.Newobj, funcConstructor));

                insertIl(il.Create(OpCodes.Newobj, storeConstructor));
                con.Body.Instructions.Insert(i, il.Create(OpCodes.Stfld, _implStoreField));
            }
        }

        protected virtual void Validate()
        {
            var nonInterface = _interfaces.FirstOrDefault(x => !x.Resolve().IsInterface);
            if (nonInterface != null)
                throw new InvalidTypeException(nonInterface, string.Format("{0} is not an interface", nonInterface));


            if (!WeavedType.IsClass)
                throw new UnsupportedJointpointException(string.Format("Cannot implement interface to {0}. Only classes allowed.", WeavedType));
        }

        private MethodDefinition OverrideMethod(MethodDefinition method)
        {
            var methodRef = Module.Import(method);

            if (method == null)
                return null;

            var childMethod = new MethodDefinition(method.Name, MethodAttributes.Private | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, method.ReturnType)
                                       {
                                           IsGetter = method.IsGetter, 
                                           IsSetter = method.IsSetter,
                                           Overrides = { methodRef },
                                           IsSpecialName = method.IsSpecialName
                                       };

            foreach(var param in method.Parameters)
                childMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, Module.Import(param.ParameterType)));
            foreach(var generic in method.GenericParameters)
                childMethod.GenericParameters.Add(new GenericParameter(generic.Name, generic.Owner));

            WeavedType.Methods.Add(childMethod);

            var il = childMethod.Body.GetILProcessor();
            il.Append(OpCodes.Ldarg_0);
            il.Append(OpCodes.Ldfld, _implStoreField);

            //il.Append(OpCodes.Callvirt, new MethodReference("GetImplementation", _implementationType, _implStoreField.FieldType));
            il.Append(OpCodes.Callvirt, _implStoreField.FieldType.SelectGenericSafeMethods(x => x.GetMethods()).First(x => x.Name == "GetImplementation"));
            
            if (! Equals(method.DeclaringType, _factoryDelegate.ReturnType.Resolve()))
                il.Append(OpCodes.Castclass, method.DeclaringType);

            foreach (var param in childMethod.Parameters)
                il.Append(OpCodes.Ldarg, param);
            il.Append(OpCodes.Callvirt, methodRef);

            il.Append(OpCodes.Ret);

            return childMethod;
        }

        public ModuleDefinition Module
        {
            get { return WeavedType.Module; }
        }
    }
}
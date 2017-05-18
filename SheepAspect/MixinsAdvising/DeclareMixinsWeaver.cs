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
    public abstract class DeclareMixinsWeaver : IWeaver
    {
        protected readonly TypeDefinition weavedType;
        private readonly DeclareMixinAdvice advice;
        protected readonly TypeReference aspectType;
        private FieldDefinition implStoreField;
        private readonly TypeReference[] interfaces;
        private MethodDefinition factoryDelegate;
        protected readonly TypeReference mainInterface;

        protected DeclareMixinsWeaver(TypeDefinition weavedType, DeclareMixinAdvice advice)
        {
            this.weavedType = weavedType;
            this.advice = advice;
            mainInterface = Module.Import(advice.MainInterface);
            aspectType = Module.Import(advice.AspectType);

            IEnumerable<TypeReference> interfaces = new[] { mainInterface };
            if (this.advice.AdditionalInterfaces != null)
            {
                interfaces = interfaces.Union(this.advice.AdditionalInterfaces.Select(x => this.weavedType.Module.Import(x)));
            }

            this.interfaces = interfaces.ToArray();
        }

        public int Priority
        {
            get { return DeclareMixinAdvice.PRIORITY; }
        }

        public void Weave()
        {
            Validate();

            var storeType = Module.Import(
                advice.AsFactory ? typeof(CachedMixinsImplementationBinding<,>) : typeof(MixinsImplementationBinding<,>))
                .MakeGenerics(aspectType, mainInterface);

            weavedType.Fields.Add(implStoreField = new FieldDefinition("<>sac_implStore_" + advice.FullName, FieldAttributes.Private, storeType));

            CreateFactoryDelegate();
            InitLazyImplField();

            foreach (var interfaceRef in interfaces)
            {
                var interfaceDef = interfaceRef.Resolve();

                if (weavedType.Interfaces.Contains(interfaceRef))
                {
                    throw new InterfaceAlreadyImplementedException(weavedType, interfaceRef);
                }

                weavedType.Interfaces.Add(interfaceRef);
                var overridenMethods = interfaceDef.Methods.ToDictionary(x => x, OverrideMethod);

                foreach (var property in interfaceDef.Properties)
                {
                    weavedType.Properties.Add(new PropertyDefinition(property.Name, property.Attributes, property.PropertyType)
                    {
                        GetMethod = overridenMethods[property.GetMethod],
                        SetMethod = overridenMethods[property.SetMethod]
                    });
                }

                foreach (var e in interfaceDef.Events)
                {
                    weavedType.Events.Add(new EventDefinition(e.Name, e.Attributes, e.EventType)
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
            weavedType.Methods.Add(factoryDelegate = new MethodDefinition("<>sac_getImpl_" + advice.FullName, MethodAttributes.Private, mainInterface));
            factoryDelegate.Parameters.Add(new ParameterDefinition(aspectType));
            WriteFactoryDelegateBody(factoryDelegate);
        }

        protected abstract void WriteFactoryDelegateBody(MethodDefinition il);

        private void InitLazyImplField()
        {
            var storeConstructor = implStoreField.FieldType.SelectGenericSafeMethods(t => t.GetConstructors()).First();
            var funcConstructor =
                weavedType.Module.Import(typeof(Func<,>)).MakeGenericInstanceType(factoryDelegate.Parameters[0].ParameterType, factoryDelegate.ReturnType)
                .SelectGenericSafeMethods(t => t.GetConstructors()).First();

            foreach (var con in weavedType.GetOrAddConstructors())
            {
                var il = con.Body.GetILProcessor();

                var i = 0;
                Action<Instruction> insertIl = instruction => il.Body.Instructions.Insert(i++, instruction);

                insertIl(il.Create(OpCodes.Ldarg_0));

                //conIl.Body.Instructions.Insert(i++, conIl.Create(OpCodes.Ldnull));
                insertIl(il.Create(OpCodes.Ldtoken, con));
                insertIl(il.Create(OpCodes.Ldtoken, weavedType));
                insertIl(il.Create(OpCodes.Call,
                     Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle))));

                insertIl(il.Create(OpCodes.Ldarg_0));

                var argArr = con.AddLocal(typeof(object[]));

                insertIl(il.Create(OpCodes.Ldc_I4, con.Parameters.Count));
                insertIl(il.Create(OpCodes.Newarr, Module.Import(typeof(object))));
                insertIl(il.Create(OpCodes.Stloc, argArr));

                foreach (var param in con.Parameters)
                {
                    insertIl(il.Create(OpCodes.Ldloc, argArr));
                    insertIl(il.Create(OpCodes.Ldc_I4, param.Index));
                    insertIl(il.Create(OpCodes.Ldarg, param));
                    if (param.ParameterType.IsValueType)
                    {
                        insertIl(il.Create(OpCodes.Box, param.ParameterType));
                    }

                    insertIl(il.Create(OpCodes.Stelem_Ref));
                }
                insertIl(il.Create(OpCodes.Ldloc, argArr));

                insertIl(il.Create(OpCodes.Ldarg_0));

                insertIl(il.Create(OpCodes.Ldftn, factoryDelegate));
                insertIl(il.Create(OpCodes.Newobj, funcConstructor));

                insertIl(il.Create(OpCodes.Newobj, storeConstructor));
                con.Body.Instructions.Insert(i, il.Create(OpCodes.Stfld, implStoreField));
            }
        }

        protected virtual void Validate()
        {
            var nonInterface = interfaces.FirstOrDefault(x => !x.Resolve().IsInterface);
            if (nonInterface != null)
            {
                throw new InvalidTypeException(nonInterface, string.Format("{0} is not an interface", nonInterface));
            }

            if (!weavedType.IsClass)
            {
                throw new UnsupportedJointpointException(string.Format("Cannot implement interface to {0}. Only classes allowed.", weavedType));
            }
        }

        private MethodDefinition OverrideMethod(MethodDefinition method)
        {
            var methodRef = Module.Import(method);

            if (method == null)
            {
                return null;
            }

            var childMethod = new MethodDefinition(method.Name, MethodAttributes.Private | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, method.ReturnType)
            {
                IsGetter = method.IsGetter,
                IsSetter = method.IsSetter,
                Overrides = { methodRef },
                IsSpecialName = method.IsSpecialName
            };

            foreach (var param in method.Parameters)
            {
                childMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, Module.Import(param.ParameterType)));
            }

            foreach (var generic in method.GenericParameters)
            {
                childMethod.GenericParameters.Add(new GenericParameter(generic.Name, generic.Owner));
            }

            weavedType.Methods.Add(childMethod);

            var il = childMethod.Body.GetILProcessor();
            il.Append(OpCodes.Ldarg_0);
            il.Append(OpCodes.Ldfld, implStoreField);

            //il.Append(OpCodes.Callvirt, new MethodReference("GetImplementation", _implementationType, _implStoreField.FieldType));
            il.Append(OpCodes.Callvirt, implStoreField.FieldType.SelectGenericSafeMethods(x => x.GetMethods()).First(x => x.Name == "GetImplementation"));

            if (!Equals(method.DeclaringType, factoryDelegate.ReturnType.Resolve()))
            {
                il.Append(OpCodes.Castclass, method.DeclaringType);
            }

            foreach (var param in childMethod.Parameters)
            {
                il.Append(OpCodes.Ldarg, param);
            }

            il.Append(OpCodes.Callvirt, methodRef);

            il.Append(OpCodes.Ret);

            return childMethod;
        }

        public ModuleDefinition Module
        {
            get { return weavedType.Module; }
        }
    }
}
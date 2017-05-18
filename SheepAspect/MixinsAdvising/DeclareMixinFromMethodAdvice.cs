using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.MixinsAdvising
{
    public class DeclareMixinFromMethodAdvice: DeclareMixinAdvice
    {
        public DeclareMixinFromMethodAdvice(IEnumerable<IPointcut> pointcuts, MethodInfo method, Type[] additionalInterfaces, bool? asFactory) 
            : base(pointcuts, method, method.ReturnType, additionalInterfaces, asFactory??true)
        {
            ImplementationFactory = method;
        }

        public MethodInfo ImplementationFactory { get; set; }

        public override string FullName
        {
            get
            {
                return string.Format("MixAsInterface/{0}::{1}", ImplementationFactory.ReflectedType.FullName, ImplementationFactory.Name);
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            yield return new Weaver(type, this);
        }

        public class Weaver: DeclareMixinsWeaver
        {
            private readonly MethodReference _implementationFactory;

            public Weaver(TypeDefinition weavedType, DeclareMixinFromMethodAdvice advice)
                : base(weavedType, advice)
            {
                _implementationFactory = Module.Import(advice.ImplementationFactory);
            
            }

            protected override void WriteFactoryDelegateBody(MethodDefinition factoryMethod)
            {
                var il = factoryMethod.Body.GetILProcessor();
                il.Append(OpCodes.Ldarg, factoryMethod.Parameters[0]);
                if (_implementationFactory.HasParameters)
                {
                    il.Append(OpCodes.Ldarg_0);
                }

                il.Append(OpCodes.Callvirt, _implementationFactory);
                il.Append(OpCodes.Ret);
            }

            protected override void Validate()
            {
                if (_implementationFactory.GenericParameters.Any())
                {
                    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", "Method must not have any generic parameter");
                }

                if (_implementationFactory.Parameters.Count > 1)
                {
                    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", "Method must take either no parameter, or 1 parameter (instance)");
                }

                //if (_implementationFactory.Parameters.Any() && !_implementationFactory.Parameters.First().ParameterType.Resolve().IsAssignableFrom(WeavedType))
                //    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", string.Format("Cannot assign {0} to {1}", _implementationFactory.Parameters.First().ParameterType, WeavedType));

                if (_implementationFactory.Resolve().IsStatic)
                {
                    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", "Method must not be static");
                }

                if (!_implementationFactory.Resolve().IsPublic)
                {
                    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", "Method must be public");
                }

                if (_implementationFactory.ReturnsVoid())
                {
                    throw new InvalidAdviceSignatureException(_implementationFactory, "DeclareMixins", string.Format("Method returns void. Method must return an implementation of mixins additionalInterfaces."));
                }

                base.Validate();
            }
        }
    }

}
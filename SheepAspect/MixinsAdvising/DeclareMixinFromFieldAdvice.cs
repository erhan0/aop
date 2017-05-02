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
    public class DeclareMixinFromFieldAdvice: DeclareMixinAdvice
    {
        public DeclareMixinFromFieldAdvice(IEnumerable<IPointcut> pointcuts, FieldInfo method, Type[] additionalInterfaces, bool? asFactory) 
            : base(pointcuts, method, method.FieldType, additionalInterfaces, asFactory??false)
        {
            ImplementationField = method;
        }

        public FieldInfo ImplementationField { get; set; }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            yield return new Weaver(type, this);
        }

        public class Weaver: DeclareMixinsWeaver
        {
            private readonly FieldReference _implementationField;

            public Weaver(TypeDefinition weavedType, DeclareMixinFromFieldAdvice advice)
                : base(weavedType, advice)
            {
                _implementationField = Module.Import(advice.ImplementationField);
            
            }

            protected override void WriteFactoryDelegateBody(MethodDefinition factoryMethod)
            {
                var il = factoryMethod.Body.GetILProcessor();
                il.Append(OpCodes.Ldarg, factoryMethod.Parameters[0]);
                il.Append(OpCodes.Ldfld, _implementationField);
                il.Append(OpCodes.Ret);
            }

            protected override void Validate()
            {
                if (_implementationField.Resolve().IsStatic)
                    throw new InvalidAdviceSignatureException(_implementationField, "DeclareMixins", "Field must not be static");

                if (!_implementationField.Resolve().IsPublic)
                    throw new InvalidAdviceSignatureException(_implementationField, "DeclareMixins", "Field must be public");

                base.Validate();
            }
        }
    }

}
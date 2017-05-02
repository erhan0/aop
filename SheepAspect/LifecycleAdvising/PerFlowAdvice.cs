using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;

namespace SheepAspect.LifecycleAdvising
{
    public class PerFlowAdvice: AdviceBase
    {
        private readonly Type _aspectType;

        public PerFlowAdvice(IEnumerable<IPointcut> pointcuts, Type aspectType) : base(pointcuts)
        {
            _aspectType = aspectType;
        }

        public override string GetFullName()
        {
            return string.Format("PerFlow/{0}", _aspectType);
        }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, "PerFlow ({0})".FormatWith(_aspectType.FullName), "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            yield return new PerFlowLifecycleWeaver(method, null, _aspectType);
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            if(property.GetMethod != null)
                yield return new PerFlowLifecycleWeaver(property.GetMethod, null, _aspectType);
            if (property.SetMethod != null)
                yield return new PerFlowLifecycleWeaver(property.SetMethod, null, _aspectType);
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            yield return new PerFlowLifecycleWeaver(method, instruction, _aspectType);
        }
    }
}
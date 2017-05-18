using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;

namespace SheepAspect.LifecycleAdvising
{
    public class PerFlowAdvice : AdviceBase
    {
        private readonly Type aspectType;

        public PerFlowAdvice(IEnumerable<IPointcut> pointcuts, Type aspectType) : base(pointcuts)
        {
            this.aspectType = aspectType;
        }

        public override string FullName
        {
            get
            {
                return string.Format("PerFlow/{0}", aspectType);
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, "PerFlow ({0})".FormatWith(aspectType.FullName), "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            yield return new PerFlowLifecycleWeaver(method, null, aspectType);
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            if(property.GetMethod != null)
            {
                yield return new PerFlowLifecycleWeaver(property.GetMethod, null, aspectType);
            }

            if (property.SetMethod != null)
            {
                yield return new PerFlowLifecycleWeaver(property.SetMethod, null, aspectType);
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            yield return new PerFlowLifecycleWeaver(method, instruction, aspectType);
        }
    }
}
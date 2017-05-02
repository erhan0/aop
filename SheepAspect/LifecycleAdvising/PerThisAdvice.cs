using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;

namespace SheepAspect.LifecycleAdvising
{
    public class PerThisAdvice: AdviceBase
    {
        private readonly Type _aspectType;
        private readonly AroundAdvice _aroundAdvice;

        public PerThisAdvice(IEnumerable<IPointcut> pointcuts, Type aspectType)
            : base(pointcuts)
        {
            var lifecycleAspectType = typeof (PerThisLifecycleAspect<>).MakeGenericType(aspectType);
            _aspectType = aspectType;
            _aroundAdvice = new AroundAdvice(pointcuts, lifecycleAspectType.GetMethod("Bind")){Priority = 900};
        }

        public override string GetFullName()
        {
            return string.Format("PerThis/{0}", _aspectType);
        }

        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, "PerFlow ({0})".FormatWith(_aspectType.FullName), "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            if (!method.IsStatic)
            {
                //yield return new PerThisLifecycleWeaver(method.DeclaringType);
                foreach (var weaver in _aroundAdvice.GetWeavers(method))
                    yield return weaver;
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            if (!method.IsStatic)
            {
                //yield return new PerThisLifecycleWeaver(method.DeclaringType);
                foreach (var weaver in _aroundAdvice.GetWeavers(method, instruction))
                    yield return weaver;
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            if((property.GetMethod == null || !property.GetMethod.IsStatic) 
                && (property.SetMethod == null || !property.SetMethod.IsStatic))
            {
                //yield return new PerThisLifecycleWeaver(property.DeclaringType);
                foreach (var weaver in _aroundAdvice.GetWeavers(property))
                    yield return weaver;
            }
        }
    }
}
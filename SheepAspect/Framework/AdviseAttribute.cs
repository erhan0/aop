using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SheepAspect.Core;

namespace SheepAspect.Framework
{
    public abstract class AdviceProvider: Attribute, IAdviceProvider
    {
        public string[] PointcutRefs { get; private set; }

        protected AdviceProvider(params string[] pointcutRefs)
        {
            PointcutRefs = pointcutRefs;
        }

        public void RegisterAdvice(AspectDefinition aspect, MemberInfo member)
        {
            var advice = CreateAdvice(member, PointcutRefs.Union(new[] { member.Name }).SelectMany(aspect.GetPointcuts));
            aspect.Advise(advice);
        }

        protected abstract IAdvice CreateAdvice(MemberInfo member, IEnumerable<IPointcut> pointcuts);
    }
}
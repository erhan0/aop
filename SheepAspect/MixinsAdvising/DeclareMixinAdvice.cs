using System;
using System.Collections.Generic;
using System.Reflection;
using SheepAspect.Core;

namespace SheepAspect.MixinsAdvising
{
    public abstract class DeclareMixinAdvice: AdviceBase
    {
        public const int PRIORITY = 90;

        public override string FullName { get; }
        public Type[] AdditionalInterfaces { get; private set; }
        public bool AsFactory { get; set; }
        public Type MainInterface { get; set; }
        public Type AspectType { get; set; }

        protected DeclareMixinAdvice(IEnumerable<IPointcut> pointcuts, MemberInfo memberInfo, Type mainInterface, Type[] additionalInterfaces, bool asFactory) : base(pointcuts)
        {
            MainInterface = mainInterface;
            AdditionalInterfaces = additionalInterfaces;
            AsFactory = asFactory;
            AspectType = memberInfo.ReflectedType;

            FullName = string.Format("MixAsInterface/{0}::{1}", AspectType.FullName, memberInfo.Name);
        }

    }
}
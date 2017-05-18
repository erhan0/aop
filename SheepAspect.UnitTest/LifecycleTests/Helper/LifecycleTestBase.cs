using System;
using NUnit.Framework;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests.Helper
{
    public abstract class LifecycleTestBase: AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof (LifecycleTestTarget);
        }

        [Arrange]
        public void SetLifecycle()
        {
            
        }
        protected override Type AspectType()
        {
            return typeof(LifecycleTestAspect);
        }

        protected override abstract ILifecycleProvider LifecycleProvider();

        protected override void SetupAspect(AspectDefinition aspect)
        {
            var pointcut = CreatePointcuts<MethodPointcut>(aspect, "target", "Name:'Method*' & InType:Name:'LifecycleTestTarget'");
            aspect.Advise(new AroundAdvice(pointcut, GetAspectMethod("Around")));
        }

        [SetUp]
        public void SetUp()
        {
            LifecycleTestAspect.NextUniqueId = 0;
        }
    }
}
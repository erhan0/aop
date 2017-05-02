using System;
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.LifecycleTests.Helper;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests
{
    public class PerThisTest: LifecycleTestBase
    {
        protected override ILifecycleProvider LifecycleProvider()
        {
            return new AspectPerThisAttribute{ ActivateOnPointcut = "MethodA"};
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            base.SetupAspect(aspect);
            CreatePointcuts<MethodPointcut>(aspect, "MethodA", "Name:'MethodA' & InType:Name:'LifecycleTestTarget'");
        }

        [Assert]
        public void ShouldUseDifferentAspectsPerInstance()
        {
            var target2 = CreateTarget();
            new[]
                {
                    Target.MethodB(),
                    Target.MethodA(),
                    Target.MethodB(),
                    Target.MethodA(),

                    target2.MethodB(),
                    target2.MethodA(),
                    target2.MethodA(),
                    target2.MethodB()
                }.Should().Equal(
                    "Original", 0, 0, 0,
                    "Original", 1, 1, 1);
        }
    }
}
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.UnitTest.LifecycleTests.Helper;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests
{
    public class TransientTest: LifecycleTestBase
    {
        protected override ILifecycleProvider LifecycleProvider()
        {
            return new AspectTransientAttribute();
        }

        [Assert]
        public void AlwaysUseDifferentInstances()
        {
            new[]
                {
                    Target.MethodA(),
                    Target.MethodB(),
                    Target.MethodA()
                }.Should().Equal(0, 1, 2);
        }
    }
}
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
                    target.MethodA(),
                    target.MethodB(),
                    target.MethodA()
                }.Should().Equal(0, 1, 2);
        }
    }
}
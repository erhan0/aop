using System;
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.UnitTest.LifecycleTests.Helper;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests
{
    public class SingletonTest: LifecycleTestBase
    {
        protected override ILifecycleProvider LifecycleProvider()
        {
            return new SingletonAspectAttribute();
        }

        [Assert]
        public void AlwaysUseTheSameInstance()
        {
            new[]
                {
                    CreateTarget().MethodA(),
                    CreateTarget().MethodB(),
                    CreateTarget().MethodA()
                }.Should().Equal(0, 0, 0);
        }
    }
}
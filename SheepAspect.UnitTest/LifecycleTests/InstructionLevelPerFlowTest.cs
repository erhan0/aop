using System;
using FluentAssertions;
using NUnit.Framework;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.LifecycleTests.Helper;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests
{
    public class InstructionLevelPerFlowTest : LifecycleTestBase
    {
        protected override ILifecycleProvider LifecycleProvider()
        {
            return new AspectPerCFlowAttribute("CallScope");
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            base.SetupAspect(aspect);
            CreatePointcuts<CallMethodPointcut>(aspect, "CallScope", "Method:(Name:'Scope' & InType:Name:'LifecycleTestTarget')");
        }

        [Assert]
        public void OnlyCreateNewAspectForEveryFlow()
        {
            var scoped1Called = false;
            var scoped2Called = false;

            CallScope(()=> MethodB().Should().Be("Original"),
                      delegate
                          {
                              MethodA().Should().Be(0);
                              CallScope(() => MethodA().Should().Be(0),
                                        delegate
                                            {
                                                MethodA().Should().Be(1);
                                                MethodB().Should().Be(1);
                                                scoped2Called = true;
                                            }, () => MethodB().Should().Be(0));
                              MethodA().Should().Be(0);
                              scoped1Called = true;
                          },
                      ()=> MethodA().Should().Be("Original"));

            scoped1Called.Should().BeTrue();
            scoped2Called.Should().BeTrue();
        }

        private object MethodA()
        {
            return CreateTarget().MethodA();
        }
        private object MethodB()
        {
            return CreateTarget().MethodB();
        }
        private void CallScope(Action before, Action scoped, Action after)
        {
            CreateTarget().CallScope(before, scoped, after);
        }
    }

    [AspectPerCFlow("CallScope")]
    public class InstructionLevelPerFlowAspect : LifecycleTestAspect
    {
    }
}
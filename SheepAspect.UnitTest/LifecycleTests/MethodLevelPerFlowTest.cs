using System;
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.LifecycleTests.Helper;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.LifecycleTests
{
    public class MethodLevelPerFlowTest: LifecycleTestBase
    {
        protected override ILifecycleProvider LifecycleProvider()
        {
            return new AspectPerCFlowAttribute("Scope");
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            base.SetupAspect(aspect);
            CreatePointcuts<MethodPointcut>(aspect, "Scope", "Name:'Scope' & InType:Name:'LifecycleTestTarget'");
        }

        [Assert]
        public void OnlyCreateNewAspectForEveryFlow()
        {
            var scoped1Called = false;
            var scoped2Called = false;

            MethodA().Should().Be("Original");
            Scope(delegate
                      {
                          MethodA().Should().Be(0);
                          MethodB().Should().Be(0);

                          Scope(delegate
                                    {
                                        MethodA().Should().Be(1);
                                        MethodB().Should().Be(1);
                                        scoped2Called = true;
                                    });
                          MethodB().Should().Be(0);
                          scoped1Called = true;
                      });
            MethodB().Should().Be("Original");

            false.Should().BeTrue();
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
        private void Scope(Action action)
        {
            CreateTarget().Scope(action);
        }
    }
}
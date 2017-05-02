using System;
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Runtime;
using SheepAspect.UnitTest.Target;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.AroundAdviceTests
{
    [TestFixture]
    public class PropertyGetAspectTest : AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof (SomeClass);
        }

        private static Func<PropertyGetJointPoint, int> _advice;
        
        protected override void SetupAspect(AspectDefinition aspect)
        {
            _advice = null;
            var pointcut = CreatePointcuts<PropertyMethodPointcut>(aspect, "SheepPoint", "Getter & Name:'SomeProperty'");
            aspect.Advise(new AroundAdvice(pointcut, GetAspectMethod("MockAdvice")));
        }

        public object MockAdvice(PropertyGetJointPoint jp)
        {
            return _advice(jp);
        }

        [Assert]
        public void CanProceedAndIntercept()
        {
            Target.SomeProperty = 10;
            _advice = j => j.Execute().As<int>() * 20;
            Assert.AreEqual(200, Target.SomeProperty);
        }

        [Assert]
        public void CanInterceptCompletely()
        {
            Target.SomeProperty = 10;
            _advice = j =>
            {
                return 100;
            };
            Assert.AreEqual(100, Target.SomeProperty);
        }
    }
}
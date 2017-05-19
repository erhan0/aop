using System;
using NUnit.Framework;
using FluentAssertions;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Runtime;
using SheepAspect.UnitTest.Target;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.AroundAdviceTests
{
    [TestFixture]
    public class FieldGetAspectTest : AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof (SomeClass);
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            advice = null;
            var pointcut = CreatePointcuts<GetFieldPointcut>(aspect, "SheepPoint", "Field: (Name: '_some*')");
            aspect.Advise(new AroundAdvice(pointcut, GetAspectMethod("MockAdvice")));
        }

        private static Func<GetFieldJointPoint, int> advice;
        public object MockAdvice(GetFieldJointPoint jp)
        {
            return advice(jp);
        }

        [Assert]
        public void CanProceedAndIntercept()
        {
            target.SetField(10);
            advice = j => j.Execute().As<int>() + 3;

            Assert.AreEqual(130, target.GetFieldTimes(10));
        }

        [Assert]
        public void CanInterceptCompletely()
        {
            target.SomeProperty = 10;
            advice = j =>
            {
                return 100;
            };
            Assert.AreEqual(1000, target.GetFieldTimes(10));
        }
    }
}
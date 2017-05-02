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
    public class FieldGetAspectTest : AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof (SomeClass);
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            _advice = null;
            var pointcut = CreatePointcuts<GetFieldPointcut>(aspect, "SheepPoint", "Field: (Name: '_some*')");
            aspect.Advise(new AroundAdvice(pointcut, GetAspectMethod("MockAdvice")));
        }

        private static Func<GetFieldJointPoint, int> _advice;
        public object MockAdvice(GetFieldJointPoint jp)
        {
            return _advice(jp);
        }

        [Assert]
        public void CanProceedAndIntercept()
        {
            Target.SetField(10);
            _advice = j => j.Execute().As<int>() + 3;

            Assert.AreEqual(130, Target.GetFieldTimes(10));
        }

        [Assert]
        public void CanInterceptCompletely()
        {
            Target.SomeProperty = 10;
            _advice = j =>
            {
                return 100;
            };
            Assert.AreEqual(1000, Target.GetFieldTimes(10));
        }
    }
}
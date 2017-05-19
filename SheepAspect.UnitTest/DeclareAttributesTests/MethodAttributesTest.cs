using System;
using System.Reflection;
using NUnit.Framework;
using SheepAspect.Core;
using SheepAspect.DeclareAttributeAdvising;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.TestHelper;
using FluentAssertions;
using System.Linq;

namespace SheepAspect.UnitTest.DeclareAttributesTests
{
    public class MethodAttributesTest : AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof(DeclareAttributeStub);
        }


        [MyTestAttribute("Constructor Arg")]
        protected override void SetupAspect(AspectDefinition aspect)
        {
            aspect.Advise(new DeclareAttributesAdvice(
                CreatePointcuts<MethodPointcut>(aspect, "TestPointcut", "Name:'TestMethod'"), 
                MethodBase.GetCurrentMethod(), typeof(object)));
        }

        [Assert]
        public void AttributeShouldBeCopiedToTargetMethod()
        {
            Type type = target.GetType();
            var attrs = type.GetMethod("TestMethod").GetCustomAttributesData();
            attrs.Should().HaveCount(1);
            attrs.First().Constructor.DeclaringType.Should().Be(typeof(MyTestAttribute));
            attrs.First().ConstructorArguments.Should().OnlyContain(x => x.Value.Equals("Constructor Arg"));
        }
    }
}
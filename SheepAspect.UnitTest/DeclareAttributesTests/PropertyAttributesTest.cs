using System;
using NUnit.Framework;
using SheepAspect.Core;
using SheepAspect.DeclareAttributeAdvising;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.UnitTest.TestHelper;
using FluentAssertions;
using System.Linq;

namespace SheepAspect.UnitTest.DeclareAttributesTests
{
    public class PropertyAttributesTest : AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof(DeclareAttributeStub);
        }


        protected override void SetupAspect(AspectDefinition aspect)
        {
            aspect.Advise(new DeclareAttributesAdvice(
                CreatePointcuts<PropertyPointcut>(aspect, "TestPointcut", "Name:'TestProperty'"), 
                GetType().GetProperty("MyAdvice"), typeof(object)));
        }

        [MyTestAttribute("Constructor Arg")]
        public int MyAdvice { get; set; }

        [Assert]
        public void AttributeShouldBeCopiedToTargetMethod()
        {
            Type type = Target.GetType();
            var attrs = type.GetProperty("TestProperty").GetCustomAttributesData();
            attrs.Should().HaveCount(1);
            attrs.First().Constructor.DeclaringType.Should().Be(typeof(MyTestAttribute));
            attrs.First().ConstructorArguments.Should().OnlyContain(x => x.Value.Equals("Constructor Arg"));
        }
    }
}
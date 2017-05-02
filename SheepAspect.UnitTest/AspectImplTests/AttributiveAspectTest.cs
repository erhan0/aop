using System;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;
using System.Linq;
using FluentAssertions;
using SheepAspect.AroundAdvising;
using SheepAspect.Aspects;
using SheepAspect.Framework;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Runtime;
using SheepAspect.TestSupport;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.AspectImplTests
{
    [TestFixture]
    public class AttributiveAspectTest
    {
        private AroundAdvice _advice;

        [SetUp]
        public void Setup()
        {
            _advice = (AroundAdvice) new AttributiveAspectProvider().GetDefinition(typeof(TestWithOnMemberBoundaryAttribute)).Advices.Single();
        }

        [Assert]
        public void CanPickOutDecoratedMethod()
        {
            _advice.Pointcuts.OfType<MethodPointcut>().Should().Contain(p=> p.MatchFull(GetMethod("DecoratedMethod")));
        }

        [Assert]
        public void CanPickOutDecoratedProperty()
        {
            var property = GetProperty("DecoratedProperty");
            _advice.Pointcuts.OfType<PropertyPointcut>()
                .Should().Contain(p => p.MatchFull(property));
        }

        //[Assert]
        //public void CanPickOutDecoratedPropertyGetter()
        //{
        //    var property = GetProperty("DecoratedPropertyGetter");
        //    _advice.Pointcuts.OfType<PropertyPointcut>()
        //        .Should().Contain(p => p.MatchFull(property.GetMethod))
        //        .And.NotContain(p => p.MatchFull(property.SetMethod));
        //}

        //[Assert]
        //public void CanPickOutDecoratedPropertySetter()
        //{
        //    var property = GetProperty("DecoratedPropertySetter");
        //    _advice.Pointcuts.OfType<PropertyPointcut>()
        //        .Should().NotContain(p => p.MatchFull(property.GetMethod))
        //        .And.Contain(p => p.MatchFull(property.SetMethod));
        //}

        [Assert]
        public void AspectInstanceShouldContainAttributeInformation()
        {
            var instance = new TestTarget();
            var aspect = new AttributiveAspectProvider().GetLifecycle(typeof (TestWithOnMemberBoundaryAttribute))
                .GetAspect(JointPoints.Method(() => instance.DecoratedMethod()));

            aspect.Should().CastTo<TestWithOnMemberBoundaryAttribute>().Text.Should().Be("MyTest");
        }

        private static MethodDefinition GetMethod(string name)
        {
            var asm = AssemblyDefinition.ReadAssembly(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return asm.MainModule.ImportMethod<TestTarget>(name).Resolve();
        }

        private static PropertyDefinition GetProperty(string name)
        {
            var asm = AssemblyDefinition.ReadAssembly(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return asm.MainModule.ImportType<TestTarget>().Resolve().Properties.First(x => x.Name == name);
        }

        public class TestWithOnMemberBoundaryAttribute: OnMemberBoundaryAttribute
        {
            public string Text { get; set; }

            public override object Around(IMemberJointPoint jp)
            {
                throw new NotImplementedException();
            }
        }

        public class TestTarget
        {
            [TestWithOnMemberBoundary(Text = "MyTest")]
            public void DecoratedMethod()
            {}

            [TestWithOnMemberBoundary]
            public int DecoratedProperty { get; set; }

            public int DecoratedPropertyGetter { [TestWithOnMemberBoundary]get; set; }

            public int DecoratedPropertySetter { get; [TestWithOnMemberBoundary]set; }
        }
    }
}
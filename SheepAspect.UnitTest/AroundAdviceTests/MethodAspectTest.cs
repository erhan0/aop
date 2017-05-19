using System;
using NUnit.Framework;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Helpers;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Runtime;
using SheepAspect.UnitTest.TestHelper;
using FluentAssertions;

namespace SheepAspect.UnitTest.AroundAdviceTests
{
    [TestFixture]
    public class MethodAspectTest: AspectTestBase
    {
        protected override Type TargetType()
        {
            return typeof(MethodTestTarget<int>);
        }

        protected override void SetupAspect(AspectDefinition aspect)
        {
            advice = null;
            var pointcut = CreatePointcuts<MethodPointcut>(aspect, "SheepPoint", "Name: ('SimpleConcat'|'Generic*') & InType:Name:'MethodTestTarget*'");
            aspect.Advise(new AroundAdvice(pointcut, GetAspectMethod("MockAdvice")));
        }

        private static Func<MethodJointPoint, object> advice;
        public object MockAdvice(MethodJointPoint jp)
        {
            return advice(jp);
        }

        [Assert]
        public void CanProceedAndIntercept()
        {
            advice = j => j.Execute() + " advised";
            Assert.AreEqual("Hello Int32 advised", target.SimpleConcat("Hello"));
        }

        [Assert]
        public void CanProceedWithAlteredArgs()
        {
            advice = j => { 
                j.Args[0] = "Hi";
                return j.Execute();
            };
            Assert.AreEqual("Hi Int32", target.SimpleConcat("Hello"));
        }

        [Assert]
        public void CanHandleGenericMethod()
        {
            advice = j => j.Execute() + " advised";
            Assert.AreEqual("Hello Int32,String advised", target.GenericConcat<int, string>("Hello"));
        }

        // BUG: https://sheepaspect.codeplex.com/workitem/11132
        [Assert]
        public void CurrentMethodShouldRetainParameterAttributes()
        {
            ((object) target).GetType().GetMethod("SimpleConcat").GetParameters()[0].GetCustomAttributes(
                typeof (FooAttribute), true).Should().NotBeEmpty();
        }
    }
    
    public class FooAttribute: Attribute
    {
        
    }

    public class MethodTestTarget<TClass>
    {
        public string SimpleConcat([Foo]string something)
        {
            return something + " " + typeof(TClass).Name;
        }

        public string GenericConcat<T,Y>(string something)
        {
            return "{0} {1},{2}".FormatWith(something, typeof(T).Name, typeof(Y).Name);
        }
    }
}
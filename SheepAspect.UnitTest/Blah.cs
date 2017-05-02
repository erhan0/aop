using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SheepAspect.UnitTest
{
    [TestFixture]
    public class TestX
    {
        [Test]
        public void TestRun()
        {
            var x = new FooX2();

            var subProp = x.GetType().GetProperty("Test");

            Assert.True(typeof(FooX2).IsAssignableFrom(subProp.DeclaringType));

            var attributes = subProp.GetCustomAttributes(true);
            Assert.True(attributes.Length > 0);
        }

        [Test]
        public void TestRun2()
        {
            var x = new FooX2();

            var subProp = x.GetType().GetMethod("Aaa");

            Assert.True(typeof(FooX2).IsAssignableFrom(subProp.DeclaringType));

            var attributes = subProp.GetCustomAttributes(true);
            Assert.True(attributes.Length > 0);
        }
    }

    public class FooX
    {
        [Blah]
        public virtual DateTime Test
        {
            get;
            set;
        }

        [Blah]
        public virtual void Aaa()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, Inherited = true)]
    public class BlahAttribute : Attribute
    {

    }

    public class FooX2 : FooX
    {
        public override DateTime Test
        {
            get
            {
                return base.Test;
            }
            set
            {
                base.Test = value;
            }
        }

        public override void Aaa()
        {
            base.Aaa();
        }
    }


}

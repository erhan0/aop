using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Saql;
using FluentAssertions;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.PointcutTests
{
    [TestFixture]
    public class InstructionPointcutTest
    {
        [Assert]
        public void FromProperty()
        {
            var pointcut = new GetFieldPointcut();
            PointcutBuilder.Instance.BuildFromSaql(new AspectDefinition(GetType()), "FromProperty:Name:'*One'", pointcut);
            var asm = AssemblyDefinition.ReadAssembly(Assembly.GetExecutingAssembly().GetName().Name + ".dll");
            
            var getter = asm.MainModule.Import(typeof(Sut).GetProperty("PropertyOne").GetGetMethod()).Resolve();
            var method = asm.MainModule.Import(typeof(Sut).GetMethod("MethodOne")).Resolve();

            pointcut.Match(getter).Should().BeTrue();
            pointcut.Match(method).Should().BeFalse();
        }

        public class Sut
        {
            private string fieldOne;

            public string PropertyOne
            {
                get { return fieldOne; }
            }

            public string MethodOne()
            {
                return fieldOne;
            }
        }
    }
}
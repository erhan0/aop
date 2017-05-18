using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using NUnit.Core;
using NUnit.Framework;

namespace SheepAspect.UnitTest.TestHelper
{
    public class AssertAttribute : TestAttribute, ITestCaseAction
    {
        private static readonly string ArrangeAttributeName = typeof(ArrangeAttribute).FullName;
        private static readonly string ActAttributeName = typeof(ActAttribute).FullName;

        public void BeforeTestCase(object fixture, MethodInfo method)
        {
            RunArranges(fixture.GetType(), fixture, ArrangeAttributeName, delegate { return false; });
            RunArranges(fixture.GetType(), fixture, ActAttributeName, (m,e)=> HandleException(fixture.GetType(), fixture, m, e));
        }

        private static void RunArranges(Type fixtureType, object instance, string attribute, Func<MethodInfo, NUnitException, bool> handleException)
        {
            if (fixtureType.IsNested)
            {
                RunArranges(fixtureType.DeclaringType, null, attribute, handleException);
            }

            foreach (var method in Reflect.GetMethodsWithAttribute(fixtureType, attribute, true))
            {
                if (instance == null && !method.IsStatic)
                {
                    throw new InvalidTestFixtureException(
                        string.Format("When you have nested-tests, [{0}] method must be made static: {1}", attribute, method));
                }

                try
                {
                    Reflect.InvokeMethod(method, instance);
                }
                catch (NUnitException e)
                {
                    if(!handleException(method, e))
                    {
                        throw;
                    }
                }
            }
        }

        private static bool HandleException(Type fixtureType, Object instance, MethodInfo method, NUnitException e)
        {
            var caught = false;
            foreach(var field in from f in fixtureType.GetFields(
                                     BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                         where f.FieldType.IsInstanceOfType(e.InnerException) &&
                            f.GetCustomAttributes(typeof(CatchException), true).OfType<CatchException>()
                                .Any(a => (a.ThrownFrom??fixtureType) == method.ReflectedType)
                         select f)
            {
                caught = true;
                if (instance == null && !field.IsStatic)
                {
                    throw new InvalidTestFixtureException(
                        string.Format("When you have nested-tests, [CatchException] field must be made static: {0}", field));
                }

                field.SetValue(instance, e.InnerException);
            }

            if(fixtureType != method.ReflectedType)
            {
                caught |= HandleException(fixtureType.DeclaringType, null, method, e);
            }

            return caught;
        }

        public IEnumerable<FieldInfo> GetExceptionFieldsForFixtureType(Type fixtureType)
        {
            return fixtureType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static |
                                         BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes(typeof(CatchException), true).Any());
        }

        public void AfterTestCase(object fixture, MethodInfo method)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ActAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ArrangeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class CatchException : Attribute
    {
        public Type ThrownFrom { get; set; }
    }
}
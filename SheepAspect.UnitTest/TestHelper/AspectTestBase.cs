using System;
using System.Reflection;
using NUnit.Framework;
using System.Linq;
using SheepAspect.Core;
using SheepAspect.Framework;
using SheepAspect.Runtime;
using SheepAspect.Saql;

namespace SheepAspect.UnitTest.TestHelper
{
    public abstract class AspectTestBase
    {
        protected abstract Type TargetType();

        protected static dynamic target;
        private static MockAspectProvider mockAspectProvider;
        private AspectDefinition aspect;

        [Arrange]
        public void Arrange()
        {
            mockAspectProvider = new MockAspectProvider();
            AspectRuntime.Provider = mockAspectProvider;

            aspect = new AspectDefinition(AspectType());
            SetupAspect(aspect);

            mockAspectProvider.AddDefinition(aspect, LifecycleProvider());
        }

        [Act]
        public void Act()
        {
            target = WeaveTestHelper.WeaveAndLoadType(GetType(), aspect, TargetType());
        }

        [TearDown]
        public void FixtureTearDown()
        {
            AspectRuntime.Provider = new AttributiveAspectProvider();
        }

        protected dynamic CreateTarget()
        {
            return WeaveTestHelper.CreateTarget(GetType(), TargetType());
        }

        protected abstract void SetupAspect(AspectDefinition aspect);

        protected virtual Type AspectType()
        {
            return GetType();
        }

        protected virtual ILifecycleProvider LifecycleProvider()
        {
            return new SingletonAspectAttribute();
        }

        protected MethodInfo GetAspectMethod(string methodName)
        {
            return AspectType().GetMethod(methodName);
        }

        protected T[] CreatePointcuts<T>(AspectDefinition aspect, string name, params string[] saqls) where T : IPointcut, new()
        {
            var builder = new PointcutBuilder();
            return saqls.Select(saql =>
                             {
                                 var pointcut = aspect.AddPointcut<T>(name);
                                 builder.BuildFromSaql(aspect, saql, pointcut);
                                 return pointcut;
                             }).ToArray();
        }
    }
}
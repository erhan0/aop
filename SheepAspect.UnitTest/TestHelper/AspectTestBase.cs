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

        protected static dynamic Target;
        private static MockAspectProvider _mockAspectProvider;
        private AspectDefinition _aspect;

        [Arrange]
        public void Arrange()
        {
            _mockAspectProvider = new MockAspectProvider();
            AspectRuntime.Provider = _mockAspectProvider;

            _aspect = new AspectDefinition(AspectType());
            SetupAspect(_aspect);

            _mockAspectProvider.AddDefinition(_aspect, LifecycleProvider());
        }

        [Act]
        public void Act()
        {
            Target = WeaveTestHelper.WeaveAndLoadType(GetType(), _aspect, TargetType());
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
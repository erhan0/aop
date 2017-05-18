using System;
using System.Collections.Generic;
using SheepAspect.Core;
using SheepAspect.Framework;

namespace SheepAspect.UnitTest.TestHelper
{
    public class MockAspectProvider: AttributiveAspectProvider
    {
        private readonly IDictionary<Type, AspectDefinition> _aspects = new Dictionary<Type, AspectDefinition>();
        private readonly IDictionary<Type, ILifecycleProvider>  _lifecycleProviders = new Dictionary<Type, ILifecycleProvider>();
        private readonly IDictionary<Type, IAspectFactory> _factories = new Dictionary<Type, IAspectFactory>();

        public override AspectDefinition GetDefinition(Type type)
        {
            AspectDefinition definition;
            if (_aspects.TryGetValue(type, out definition))
            {
                return definition;
            }

            return base.GetDefinition(type);
        }

        public override ILifecycleProvider GetLifecycleProvider(Type aspectType)
        {
            ILifecycleProvider provider;
            if (!_lifecycleProviders.TryGetValue(aspectType, out provider))
            {
                provider = base.GetLifecycleProvider(aspectType);
            }

            Console.WriteLine("Getting lc {0}: {1}", aspectType, provider);
            return provider;
        }

        public override IAspectFactory GetFactory(Type aspectType)
        {
            IAspectFactory factory;
            if (_factories.TryGetValue(aspectType, out factory))
            {
                return factory;
            }

            return base.GetFactory(aspectType);
        }

        public void AddDefinition(AspectDefinition aspect, ILifecycleProvider lifecycleProvider)
        {
            lifecycleProvider.RegisterAdvices(aspect);

            _aspects.Add(aspect.Type, aspect);
            _lifecycleProviders[aspect.Type] =  lifecycleProvider;
        }

        public void SetFactory<TAspect>(IAspectFactory factory)
        {
            _factories[typeof (TAspect)] = factory;
        }
    }
}
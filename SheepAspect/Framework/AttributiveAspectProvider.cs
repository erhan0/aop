using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SheepAspect.Core;
using SheepAspect.Helpers;

namespace SheepAspect.Framework
{
    public class AttributiveAspectProvider: IAspectProvider
    {
        private readonly IDictionary<Type, IAspectLifecycle> _aspectLifecycles = new Dictionary<Type, IAspectLifecycle>();
        
        public AttributiveAspectProvider()
        {
            DefaultFactory = new SimpleAspectFactory();
            DefaultLifecycleProvider = new SingletonAspectAttribute();
        }

        public IAspectFactory DefaultFactory { get; set; }
        public ILifecycleProvider DefaultLifecycleProvider { get; set; }

        public virtual AspectDefinition GetDefinition(Type type)
        {
            if(!type.IsAbstract && type.IsClass && type.GetCustomAttributes(typeof(AspectAttribute), true).Any())
            {
                var member = type.GetMembers();

                var memberAdvices = member.SelectMany(m => m.GetCustomAttributes(typeof(IAdviceProvider), true)
                          .Cast<IAdviceProvider>().Select(a => new KeyValuePair<MemberInfo, IAdviceProvider>(m, a))
                    );

                return BuildAspect(type, memberAdvices);
            }
            return null;
        }

        public virtual ILifecycleProvider GetLifecycleProvider(Type aspectType)
        {
            return (ILifecycleProvider) aspectType.GetCustomAttributes(typeof (ILifecycleProvider), true).FirstOrDefault()?? DefaultLifecycleProvider;
        }

        public virtual IAspectLifecycle GetLifecycle(Type aspectType)
        {
            return _aspectLifecycles.GetOrPut(aspectType,
                   () => GetLifecycleProvider(aspectType).GetLifecycle(aspectType, GetFactory(aspectType)));
        }

        public virtual IAspectFactory GetFactory(Type aspectType)
        {
            var factoryAttribute = (UseFactoryAttributeBase)aspectType.GetCustomAttributes(typeof(UseFactoryAttributeBase), true).FirstOrDefault();
            if (factoryAttribute == null)
                return DefaultFactory;
            return factoryAttribute.GetFactory();
        }

        private AspectDefinition BuildAspect(Type type, IEnumerable<KeyValuePair<MemberInfo, IAdviceProvider>> memberAdvices)
        {
            var aspect = new AspectDefinition(type);
            Parallel.ForEach(type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), m =>
            {
                foreach (
                    var p in
                        m.GetCustomAttributes(typeof(IPointcutProvider), true).
                            Cast<IPointcutProvider>())
                    p.RegisterPointcut(aspect, m.Name);
            });

            Parallel.ForEach(memberAdvices, a => a.Value.RegisterAdvice(aspect, a.Key));

            var lifecycleProvider = GetLifecycleProvider(type);
            if (lifecycleProvider != null)
                lifecycleProvider.RegisterAdvices(aspect);
            return aspect;
        }
    }
}
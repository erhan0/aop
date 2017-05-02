using System;
using SheepAspect.Core;
using SheepAspect.Runtime;
using StructureMap;

namespace ShoppingCartAutoAlert
{
    public class StructureMapAspectFactory : IAspectFactory
    {
        private readonly Container _container;

        public StructureMapAspectFactory(Container container)
        {
            _container = container;
        }

        public object CreateInstance(Type type, IJointPoint joinpoint)
        {
            return _container.GetInstance(type);
        }
    }
}
using System;
using SheepAspect.Core;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that an aspect class will only be instantiated once during the lifetime of the application.
    /// </summary>
    public class SingletonAspectAttribute : AspectAttribute, ILifecycleProvider
    {
        public IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory)
        {
            return new SingletonAspectLifecycle(aspectType, factory);
        }

        public void RegisterAdvices(AspectDefinition aspect)
        {
        }
    }
}
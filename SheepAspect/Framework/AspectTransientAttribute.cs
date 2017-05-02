using System;
using SheepAspect.Core;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that an aspect class will always be instantiated for every advice execution. Not recommended.
    /// </summary>
    public class AspectTransientAttribute : AspectAttribute, ILifecycleProvider
    {
        public IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory)
        {
            return new TransientAspectLifecycle(jp=> factory.CreateInstance(aspectType, jp));
        }

        public void RegisterAdvices(AspectDefinition aspect)
        {
        }
    }
}
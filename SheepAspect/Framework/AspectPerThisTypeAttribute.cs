using System;
using SheepAspect.Core;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that an aspect class will always be instantiated for every advice execution. Not recommended.
    /// </summary>
    public class AspectPerThisTypeAttribute : AspectAttribute, ILifecycleProvider
    {
        public IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory)
        {
            return new PerThisTypeAspectLifecycle(jp=> factory.CreateInstance(aspectType, jp));
        }

        public void RegisterAdvices(AspectDefinition aspect)
        {
        }
    }
}
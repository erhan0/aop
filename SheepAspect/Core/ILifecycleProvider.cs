using System;

namespace SheepAspect.Core
{
    public interface ILifecycleProvider
    {
        IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory);
        void RegisterAdvices(AspectDefinition aspect);
    }
}
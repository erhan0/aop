using System;

namespace SheepAspect.Core
{
    public interface IAspectProvider
    {
        IAspectFactory DefaultFactory { get; set; }

        AspectDefinition GetDefinition(Type type);
        IAspectLifecycle GetLifecycle(Type aspectType);
        IAspectFactory GetFactory(Type aspectType);
    }
}
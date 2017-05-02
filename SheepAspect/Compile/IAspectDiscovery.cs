using System.Collections.Generic;
using SheepAspect.Core;

namespace SheepAspect.Compile
{
    public interface IAspectDiscovery
    {
        IEnumerable<AspectDefinition> DiscoverAspects();
    }
}
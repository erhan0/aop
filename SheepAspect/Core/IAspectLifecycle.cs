using SheepAspect.Runtime;

namespace SheepAspect.Core
{
    public interface IAspectLifecycle
    {
        object GetAspect(IJointPoint jointPoint);
    }
}
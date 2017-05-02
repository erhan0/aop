using SheepAspect.Runtime;

namespace SheepAspect.Framework
{
    public interface IAspectAware
    {
        void OnCreated(IJointPoint jp);
    }
}
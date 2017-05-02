using System;
using SheepAspect.Runtime;

namespace SheepAspect.Core
{
    public interface IAspectFactory
    {
        object CreateInstance(Type type, IJointPoint joinpoint);
    }
}
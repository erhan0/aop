using System.Reflection;

namespace SheepAspect.Core
{
    public interface IPointcutProvider
    {
        IPointcut RegisterPointcut(AspectDefinition aspect, string pointcutName);
    }
}
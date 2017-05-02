using System.Reflection;

namespace SheepAspect.Core
{
    public interface IAdviceProvider
    {
        void RegisterAdvice(AspectDefinition aspect, MemberInfo method);
    }
}
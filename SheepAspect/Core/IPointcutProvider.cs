namespace SheepAspect.Core
{
    public interface IPointcutProvider
    {
        IPointcut RegisterPointcut(AspectDefinition aspect, string pointcutName);
    }
}
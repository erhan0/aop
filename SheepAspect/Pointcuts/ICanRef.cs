using SheepAspect.Core;

namespace SheepAspect.Pointcuts
{
    public interface ICanRef
    {
        /// <summary>
        /// Support for @otherPointcut
        /// </summary>
        /// <param name="referrer">The top-level pointcut, in case the reference is invalid and we want the exception to explain the source of the trouble</param>
        /// <param name="aspect">Aspect that owns the referenced pointcut</param>
        /// <param name="pointcutName">Name of the referenced pointcut</param>
        void WhereRef(IPointcut referrer, AspectDefinition aspect, string pointcutName);
    }
}
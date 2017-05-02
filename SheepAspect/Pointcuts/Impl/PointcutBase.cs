using System;
using SheepAspect.Core;
using System.Linq;

namespace SheepAspect.Pointcuts.Impl
{
    public abstract class PointcutBase<T>: IPointcut, IWhereAny<T>, ICanRef where T: IPointcut
    {
        public string Name { get; set; }

        /// <summary>
        /// Support for @otherPointcut
        /// </summary>
        /// <param name="referrer">The top-level pointcut, in case the reference is invalid and we want the exception to explain the source of the trouble</param>
        /// <param name="aspect">Aspect that owns the referenced pointcut</param>
        /// <param name="pointcutName">Name of the referenced pointcut</param>
        public void WhereRef(IPointcut referrer, AspectDefinition aspect, string pointcutName)
        {
            WhereAny(()=> aspect.GetPointcutForRef<T>(pointcutName, referrer).ToArray());
        }

        public abstract void WhereAny(Func<T[]> func);

        public void WhereAny(params T[] pointcuts)
        {
            WhereAny(()=> pointcuts);
        }
    }
}
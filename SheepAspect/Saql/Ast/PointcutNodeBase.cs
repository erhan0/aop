using System;
using SheepAspect.Core;
using SheepAspect.Saql.Exceptions;

namespace SheepAspect.Saql.Ast
{
    public abstract class PointcutNodeBase: IPointcutValueNode
    {
        protected PointcutNodeBase(AspectDefinition aspect)
        {
            Aspect = aspect;
        }

        protected AspectDefinition Aspect { get; set; }

        public object Build(object pointcut)
        {
            return ((dynamic)this).BuildFor((dynamic)pointcut);
        }

        protected virtual object BuildFor(object pointcut)
        {
            throw new UnsupportedSaqlConstructException(this, pointcut);
        }

        protected virtual T[] BuildFor<T>(T[] obj) where T : new()
        {
            return new[] {(T)Build(Construct(typeof(T)))};
        }

        public object Construct(Type type)
        {
            return type.IsArray ? Array.CreateInstance(type.GetElementType(), 0) : Activator.CreateInstance(type);
        }
    }
}
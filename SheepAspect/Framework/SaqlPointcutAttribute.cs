using SheepAspect.Core;
using SheepAspect.Saql;

namespace SheepAspect.Framework
{
    public abstract class SaqlPointcutAttribute: PointcutAttribute
    {
        private readonly string _saql;

        protected SaqlPointcutAttribute(string saql)
        {
            _saql = saql;
        }

        public override IPointcut RegisterPointcut(AspectDefinition aspect, string pointcutName)
        {
            var pointcut = CreatePointcut(aspect, pointcutName);
            PointcutBuilder.Instance.BuildFromSaql(aspect, _saql, pointcut);
            return pointcut;
        }

        protected abstract IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName);
    }
}
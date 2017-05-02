using System;
using SheepAspect.Core;
using SheepAspect.Pointcuts;

namespace SheepAspect.Saql.Ast
{
    public class OrCompoundNode : PointcutNodeBase
    {
        public OrCompoundNode(AspectDefinition aspect, IPointcutValueNode left, IPointcutValueNode right) : base(aspect)
        {
            Left = left;
            Right = right;
        }

        public IPointcutValueNode Left { get; set; }
        public IPointcutValueNode Right { get; set; }

        public object BuildFor<T>(IWhereAny<T> pointcut)
        {
            var l = (T)Left.Build(Construct(pointcut.GetType()));
            var r = (T)Right.Build(Construct(pointcut.GetType()));

            pointcut.WhereAny(l, r);
            return pointcut;
        }
    }
}
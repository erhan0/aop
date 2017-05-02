using SheepAspect.Core;
using SheepAspect.Helpers;

namespace SheepAspect.Saql.Ast
{
    public class AndCompoundNode: PointcutNodeBase
    {
        public AndCompoundNode(AspectDefinition aspect, IPointcutValueNode left, IPointcutValueNode right): base(aspect)
        {
            Left = left;
            Right = right;
        }

        public IPointcutValueNode Left { get; set; }
        public IPointcutValueNode Right { get; set; }

        protected override object BuildFor(object obj)
        {
            Left.Build(obj);
            Right.Build(obj);
            return obj;
        }

        public override string ToString()
        {
            return "{0} & {1}".FormatWith(Left, Right);
        }
    }
}
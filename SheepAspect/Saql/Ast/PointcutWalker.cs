using Antlr.Runtime.Tree;
using SheepAspect.Core;

namespace SheepAspect.Saql.Ast
{
    public partial class PointcutWalker
    {
        public PointcutWalker(AspectDefinition aspect, IPointcut pointcut, ITreeNodeStream input): this(input)
        {
            Aspect = aspect;
            Pointcut = pointcut;
        }

        protected AspectDefinition Aspect { get; set; }
        public IPointcut Pointcut { get; set; }
    }
}
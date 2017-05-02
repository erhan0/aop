using Antlr.Runtime;
using Antlr.Runtime.Tree;
using SheepAspect.Core;
using SheepAspect.Saql.Exceptions;

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
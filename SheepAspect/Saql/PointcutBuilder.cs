using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using SheepAspect.Exceptions;
using SheepAspect.Saql.Ast;
using SheepAspect.Core;

namespace SheepAspect.Saql
{
    public class PointcutBuilder
    {
        public static PointcutBuilder Instance = new PointcutBuilder();
        public void BuildFromSaql(AspectDefinition aspect, string saql, IPointcut pointcut)
        {
            try
            {
                var lexer = new PointcutLexer(new ANTLRStringStream(saql));
                var parser = new PointcutParser(new CommonTokenStream(lexer));

                var walker = new PointcutWalker(aspect, pointcut, new CommonTreeNodeStream(parser.pointcut().Tree));

                var node = walker.pointcut().value;
                if(node != null)
                {
                    node.Build(pointcut);
                }
            }
            catch(SheepAspectException e)
            {
                throw new PointcutDefinitionException(aspect, pointcut, e);
            }
            catch (Exception e)
            {
                throw new PointcutDefinitionException(aspect, pointcut, "Error parsing pointcut: " + e.Message, e);
            }
            
        }
    }
}
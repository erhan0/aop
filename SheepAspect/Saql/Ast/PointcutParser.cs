using SheepAspect.Saql.Exceptions;

namespace SheepAspect.Saql.Ast
{
    public partial class PointcutParser
    {
         public override void ReportError(Antlr.Runtime.RecognitionException e)
        {
            throw new UnexpectedTokenSaqlException(e);
        }
    }
}
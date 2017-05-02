using SheepAspectQueryAnalyzer.Exceptions;

namespace SheepAspectQueryAnalyzer.Engine.Parser
{
    public partial class SaqaLexer
    {
        public override void ReportError(Antlr.Runtime.RecognitionException e)
        {
            throw new UnexpectedTokenSaqaException(e);
        }
    }
}
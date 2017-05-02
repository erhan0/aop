using Antlr.Runtime;
using SheepAspectQueryAnalyzer.Exceptions;

namespace SheepAspectQueryAnalyzer.Engine.Parser
{
    public partial class SaqaParser
    {
        public string ProcessString(IToken token)
        {
            if (token.Text.Length < 2 || !token.Text.StartsWith("\"") || !token.Text.EndsWith("\""))
                throw new RecognitionException(string.Format("'{0}' is not a valid string", token.Text));
            return token.Text.Substring(1, token.Text.Length - 2);
        }

        public override void ReportError(Antlr.Runtime.RecognitionException e)
        {
            throw new UnexpectedTokenSaqaException(e);
        }
    }
}
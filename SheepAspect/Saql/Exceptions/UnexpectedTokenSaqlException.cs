using System.Text;
using Antlr.Runtime;
using SheepAspect.Helpers;

namespace SheepAspect.Saql.Exceptions
{
    public class UnexpectedTokenSaqlException: SaqlException
    {
        public UnexpectedTokenSaqlException(RecognitionException e)
            : base(GetMessage(e), e)
        {

        }

        private static string GetMessage(RecognitionException e)
        {
            var pointerBuilder = new StringBuilder(e.CharPositionInLine + 1);
            for (var i = 0; i < e.CharPositionInLine; i++)
                pointerBuilder.Append('-');
            pointerBuilder.Append('^');
            return "Error at {0}:{1}.\r\n\"{2}\"\r\n-{3}".FormatWith(e.Line, e.CharPositionInLine, e.Input, pointerBuilder);
        }
    }
}
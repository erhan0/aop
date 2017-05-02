using SheepAspect.Saql.Ast;

namespace SheepAspect.Saql.Exceptions
{
    public class MissingArgumentSaqlException: SaqlException
    {
        public MissingArgumentSaqlException(CriteriaNode node)
            : base(string.Format("Missing argument for criteria: {0}", node))
        {
        }
    }

    public class UnexpectedArgumentSaqlException : SaqlException
    {
        public UnexpectedArgumentSaqlException(CriteriaNode node)
            : base(string.Format("Argument unexpected for criteria: {0}", node))
        {
        }
    }
}
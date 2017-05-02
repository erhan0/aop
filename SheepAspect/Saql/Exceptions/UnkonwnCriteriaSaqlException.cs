using SheepAspect.Saql.Ast;

namespace SheepAspect.Saql.Exceptions
{
    public class UnkonwnCriteriaSaqlException : SaqlException
    {
        public UnkonwnCriteriaSaqlException(CriteriaNode criteriaNode, object pointcut): base(string.Format("Unknown criteria '{0}' for {1}", criteriaNode, pointcut))
        {
        }
    }
}
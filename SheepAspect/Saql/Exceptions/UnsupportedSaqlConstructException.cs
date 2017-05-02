using SheepAspect.Saql.Ast;

namespace SheepAspect.Saql.Exceptions
{
    public class UnsupportedSaqlConstructException: SaqlException
    {
        public UnsupportedSaqlConstructException(IPointcutValueNode node, object pointcut): 
            base(string.Format("Cannot apply {0} SAQL query to {1}", node, pointcut))
        {
        }
    }
}
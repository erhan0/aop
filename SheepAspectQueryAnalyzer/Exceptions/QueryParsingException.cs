using System;
using SheepAspectQueryAnalyzer.Engine;

namespace SheepAspectQueryAnalyzer.Exceptions
{
    public class QueryParsingException: ApplicationException
    {
        public QueryParsingException(string pointcutName, PointcutExpression pointcutExpression, string message) :
            base(GetMessage(pointcutName, pointcutExpression, message))
        {
            
        }

        public QueryParsingException(string pointcutName, PointcutExpression pointcutExpression, Exception e) :
            base(GetMessage(pointcutName, pointcutExpression, e.Message), e)
        {

        }

        private static string GetMessage(string pointcutName, PointcutExpression pointcutExpression, string message)
        {
            return string.Format("Failed parsing {0} = [{1}(\"{2}\")].\n{3}", 
                pointcutName,
                pointcutExpression.AttributeName, 
                pointcutExpression.Saql, 
                message);
        }
    }
}
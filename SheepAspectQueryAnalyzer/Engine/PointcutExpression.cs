namespace SheepAspectQueryAnalyzer.Engine
{
    public class PointcutExpression
    {
        public PointcutExpression(string alias, string attributeName, string saql)
        {
            Alias = alias;
            AttributeName = attributeName;
            Saql = saql;
        }

        public string Alias { get; private set; }
        public string AttributeName { get; private set; }
        public string Saql { get; private set; }
    }
}
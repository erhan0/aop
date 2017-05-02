using SheepAspect.Core;
using SheepAspect.Pointcuts;

namespace SheepAspect.Saql.Ast
{
    public class LiteralValueNode : PointcutNodeBase
    {
        public LiteralValueNode(AspectDefinition aspect, string value): base(aspect)
        {
            Value = value;
        }
        public string Value { get; set; }

        public object BuildFor(IWhereLiteral criteria)
        {
            criteria.WhereLiteral(Value);
            return criteria;
        }
    }
}
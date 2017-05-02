using FluentAssertions;
using SheepAspect.Saql.Ast;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.SaqlTests
{
    public static class TestHelper
    {
        public static CriteriaNode ShouldBeCriteria(this IPointcutValueNode node, string property)
        {
            var criteria = node.Should().CastTo<CriteriaNode>();
            criteria.Property.Should().Be(property);
            return criteria;
        }

        public static LiteralValueNode ShouldBeLiteral(this IPointcutValueNode node, string value)
        {
            node.Should().CastTo<LiteralValueNode>()
                .Value.Should().Be(value);
            return (LiteralValueNode) node;
        }
    }
}
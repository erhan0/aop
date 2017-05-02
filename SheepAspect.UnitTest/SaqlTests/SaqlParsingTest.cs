using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using SheepAspect.Saql.Ast;
using FluentAssertions;
using SheepAspect.Saql.Exceptions;
using SheepAspect.UnitTest.TestHelper;

namespace SheepAspect.UnitTest.SaqlTests
{
    [TestFixture]
    public class SaqlParsingTest
    {
        [Assert]
        public void HenTest()
        {
            var str = "";
            var lexer = new PointcutLexer(new ANTLRStringStream(str));
            var parser = new PointcutParser(new CommonTokenStream(lexer));

            var q = parser.pointcut();
            new DumpAstVisitor().visit((ITree) q.Tree);
        }

        [Assert]
        public void Empty()
        {
            Process("").Should().BeNull();
        }

        [Assert]
        public void SimpleCriteria()
        {
            Process("Name: 'Sheep'")
                .ShouldBeCriteria("Name")
                .Value.ShouldBeLiteral("Sheep");
        }

        [Assert]
        public void ArgumentlessCriteria()
        {
            Process("IsStatic")
                .ShouldBeCriteria("IsStatic")
                .Value.Should().BeNull();
        }

        [Assert]
        public void SimpleLiteralValue()
        {
            Process("'void Hello()'")
                .ShouldBeLiteral("void Hello()");
        }

        [Assert]
        public void CriteriaWithinCriteria()
        {
            Process("WeavedType: (Name: 'Sheep')")
                .ShouldBeCriteria("WeavedType")
                .Value.ShouldBeCriteria("Name")
                .Value.ShouldBeLiteral("Sheep");
        }

        [Assert]
        public void NegationOnLiteral()
        {
            Process("Implements: !'String'").ShouldBeCriteria("Implements")
                .Value.ShouldBeCriteria("Not")
                .Value.ShouldBeLiteral("String");
        }

        [Assert]
        public void NegationOnCriteria()
        {
            Process("!Implements: 'String'").ShouldBeCriteria("Not")
                .Value.ShouldBeCriteria("Implements")
                .Value.ShouldBeLiteral("String");
        }

        [Assert]
        public void CriteriaAndCriteriaAndLiteral()
        {
            var and = Process("Name: 'Sheep' & WeavedType: 'Bull'").Should().CastTo<AndCompoundNode>();

            and.Left.ShouldBeCriteria("Name")
                .Value.ShouldBeLiteral("Sheep");
            and.Right.ShouldBeCriteria("WeavedType")
                .Value.ShouldBeLiteral("Bull");
        }

        [Assert]
        public void ArgumentlessCriteriaAndArgumentlessCriteria()
        {
            var and = Process("Private & Public").Should().CastTo<AndCompoundNode>();

            and.Left.ShouldBeCriteria("Private")
                .Value.Should().BeNull();
            and.Right.ShouldBeCriteria("Public")
                .Value.Should().BeNull();
        }

        [Assert]
        public void LiteralAndCriteriaWithinCriteria()
        {
            var and = Process("WeavedType: (Name: 'Sheep' & Assembly: 'Bull')")
                .ShouldBeCriteria("WeavedType")
                .Value.Should().CastTo<AndCompoundNode>();

            and.Left.ShouldBeCriteria("Name")
                .Value.ShouldBeLiteral("Sheep");
            and.Right.ShouldBeCriteria("Assembly")
                .Value.ShouldBeLiteral("Bull");
        }

        [Assert]
        public void CriteriaOrCriteria()
        {
            var or = Process("Name: 'Sheep' | WeavedType: 'Bull'").Should().CastTo<OrCompoundNode>();

            or.Left.ShouldBeCriteria("Name")
                .Value.ShouldBeLiteral("Sheep");
            or.Right.ShouldBeCriteria("WeavedType")
                .Value.ShouldBeLiteral("Bull");
        }
        
        [Assert]
        public void ComplexAndOr()
        {
            var andSix = Process("'One' & 'Two' & 'Three' | 'Four' | 'Five' & 'Six'").Should().CastTo<AndCompoundNode>();
            andSix.Right.ShouldBeLiteral("Six");
            
            var orFive = andSix.Left.Should().CastTo<OrCompoundNode>();
            orFive.Right.ShouldBeLiteral("Five");

            var orFour = orFive.Left.Should().CastTo<OrCompoundNode>();
            orFour.Right.ShouldBeLiteral("Four");

            var andThree = orFour.Left.Should().CastTo<AndCompoundNode>();
            andThree.Right.ShouldBeLiteral("Three");

            var andTwo = andThree.Left.Should().CastTo<AndCompoundNode>();
            andTwo.Right.ShouldBeLiteral("Two");
            andTwo.Left.ShouldBeLiteral("One");
        }

        [Assert]
        public void SimpleArrayValue()
        {
            var values = Process("('Sheep', 'Bull')").Should().CastTo<ArrayValueNode>().Values;
            values[0].ShouldBeLiteral("Sheep");
            values[1].ShouldBeLiteral("Bull");
        }

        [Assert]
        public void CriteriaWithArrayValue()
        {
            var values = Process("Args: ('Sheep', 'Bull')")
                .ShouldBeCriteria("Args")
                .Value.Should().CastTo<ArrayValueNode>().Values;
            values[0].ShouldBeLiteral("Sheep");
            values[1].ShouldBeLiteral("Bull");
        }

        [Assert]
        public void CriteriaWithPointcutRef()
        {
            Process("WeavedType: @MyOtherPointcut")
                .ShouldBeCriteria("WeavedType")
                .Value.Should().CastTo<PointcutRefNode>()
                .PointcutName.Should().Be("MyOtherPointcut");
        }

        [Assert]
        public void CriteriaWithArrayOfPointcuts()
        {
            var values = Process("Args: (@Pointcut1, @Pointcut2)")
                .ShouldBeCriteria("Args")
                .Value.Should().CastTo<ArrayValueNode>().Values;
            
            values[0].Should().CastTo<PointcutRefNode>()
                .PointcutName.Should().Be("Pointcut1");
            values[1].Should().CastTo<PointcutRefNode>()
                .PointcutName.Should().Be("Pointcut2");
        }

        [Assert]
        [ExpectedException(typeof(UnexpectedTokenSaqlException))]
        public void InvalidSaql_ShouldThrowException()
        {
            Process("Name: 'Sheep"); //No closing quote
        }

        private static IPointcutValueNode Process(string text)
        {
            var lexer = new PointcutLexer(new ANTLRStringStream(text));
            var parser = new PointcutParser(new CommonTokenStream(lexer));
            //new DumpAstVisitor().visit((ITree)parser.pointcut().Tree);

            var walker = new PointcutWalker(new CommonTreeNodeStream(parser.pointcut().Tree));

            return walker.pointcut().value;
        }

    }
}
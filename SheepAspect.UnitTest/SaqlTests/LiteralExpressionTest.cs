using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using SheepAop.Saql.Ast;

namespace SheepAop.UnitTest.SaqlTests
{
    [TestFixture]
    public class LiteralExpressionTest
    {
        [Test]
        public void HenTest(string aa)
        {
            var str = "public System..String::IndexOf()";
            var lexer = new LiteralExpressionLexer(new ANTLRStringStream(str));
            var parser = new LiteralExpressionParser(new CommonTokenStream(lexer));

            var q = parser.methodExp();
            new DumpAstVisitor().visit((ITree)q.Tree);
        }
    }
}
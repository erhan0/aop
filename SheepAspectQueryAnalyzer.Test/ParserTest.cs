using NUnit.Framework;
using SheepAspectQueryAnalyzer.Engine;
using FluentAssertions;
using System.Linq;

namespace SheepAspectQueryAnalyzer.Test
{
    [TestFixture]
    public class ParserTest
    {
        private QueryParseEngine _engine;

        [SetUp]
        public void Setup()
        {
            _engine = new QueryParseEngine();
        }

        [Test]
        public void TestParseNoPointcut()
        {
            var results = _engine.Parse("\r\n");
            results.Should().BeEmpty();
        }

        [Test]
        public void TestParse1Pointcut()
        {
            var results = _engine.Parse("[SelectMethods(\"Name:'Sheep'\")]");
            results.Should().HaveCount(1);

            var query = results.First();
            query.Saql.Should().Be("Name:'Sheep'");
            query.AttributeName.Should().Be("SelectMethods");
            query.Alias.Should().BeNull();
        }

        [Test]
        public void TestParse1AliasedPointcut()
        {
            var results = _engine.Parse("SheepAlias=[SelectMethods(\"Name:'Sheep'\")]");
            results.Should().HaveCount(1);

            var query = results.First();
            query.Saql.Should().Be("Name:'Sheep'");
            query.AttributeName.Should().Be("SelectMethods");
            query.Alias.Should().Be("SheepAlias");
        }

        [Test]
        public void TestParse2Pointcuts()
        {
            var results = _engine.Parse("[SelectMethods(\"Name:'Sheep'\")]\r\nSomeAlias=[SelectTypes(\"Name:'AnotherSheep'\")]");
            results.Should().HaveCount(2);

            var query = results.First();
            query.Saql.Should().Be("Name:'Sheep'");
            query.AttributeName.Should().Be("SelectMethods");
            query.Alias.Should().BeNull();

            query = results.ElementAt(1);
            query.Saql.Should().Be("Name:'AnotherSheep'");
            query.AttributeName.Should().Be("SelectTypes");
            query.Alias.Should().Be("SomeAlias");
        }
    }
}
using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;
using SheepAop.Compile;
using SheepAop.Pointcuts;
using SheepAop.Saql;
using SheepAop.CecilExtensions;
using FluentAssertions;

namespace SheepAop.UnitTest.PointcutTests
{
    [TestFixture]
    public class MethodByExpressionTest
    {
        public MethodPointcut Pointcut(string saql)
        {
            var aspect = new AspectDefinition(GetType());
            var pointcut = aspect.CreatePointcut<MethodPointcut>(saql);
            new PointcutBuilder().BuildFromSaql(aspect, saql, pointcut);
            return pointcut;
        }

        public MethodDefinition Method<T>(string methodName, params Type[] args)
        {
            return
                AssemblyDefinition.ReadAssembly(new Uri(GetType().Assembly.CodeBase).AbsolutePath).MainModule.
                    ImportMethod<T>(methodName, args).Resolve();
        }


        [Test]
        public void MatchByCompleteExpression()
        {
            var pointcut = Pointcut("'System.Int32 System.String::IndexOf(System.Char)'");
            pointcut.Match(Method<string>("IndexOf", typeof(char))).Should().BeTrue();
            pointcut.Match(Method<string>("IndexOf", typeof (string))).Should().BeFalse();
        }

        [Test]
        public void MatchByWildcardArgs()
        {
            var pointcut = Pointcut("'System.Int32 System.String::IndexOf(*)'");
            pointcut.Match(Method<string>("IndexOf", typeof(char))).Should().BeTrue();
            pointcut.Match(Method<string>("IndexOf", typeof(string))).Should().BeTrue();
        }

        [Test]
        public void MatchByWildcardSecondArg()
        {
            var pointcut = Pointcut("'System.Int32 System.String::IndexOf(*)'");
            pointcut.Match(Method<string>("IndexOf", typeof(char))).Should().BeTrue();
            pointcut.Match(Method<string>("IndexOf", typeof(string))).Should().BeTrue();
        }

        [Test]
        public void MatchByWildcardReturnType()
        {
            var pointcut = Pointcut("'* System.String::IndexOf(*)'");
            pointcut.Match(Method<string>("IndexOf", typeof(char))).Should().BeTrue();
            pointcut.Match(Method<string>("IndexOf", typeof(string))).Should().BeTrue();
        }
    }
}
using System;
using System.Collections.Generic;
using Antlr.Runtime;
using SheepAspect.Core;
using System.Linq;
using SheepAspect.Framework;
using SheepAspectQueryAnalyzer.Engine.Parser;
using SheepAspectQueryAnalyzer.Exceptions;

namespace SheepAspectQueryAnalyzer.Engine
{
    public class QueryParseEngine
    {
        public IEnumerable<PointcutExpression> Parse(string queryText)
        {
            var lexer = new SaqaLexer(new ANTLRStringStream(queryText));
            var parser = new SaqaParser(new CommonTokenStream(lexer));

            return parser.pointcuts().values;
        }

        public IDictionary<PointcutExpression, IPointcut> BuildPointcuts(string queryText)
        {
            var aspect = new AspectDefinition(typeof(object));
            var index = 0;
            Func<PointcutExpression, string> getPointcutName = p =>
                                                                   {
                                                                       index++;
                                                                       if (p.Alias == null)
                                                                           return "Pointcut" + index;
                                                                       return p.Alias;
                                                                   };

            return Parse(queryText).ToDictionary(x=> x, x => RegisterPointcut(x, getPointcutName(x), aspect));
        }

        private static IPointcut RegisterPointcut(PointcutExpression pointcutExpression, string pointcutName, AspectDefinition aspect)
        {
            try
            {
                return CreatePointcutProvider(pointcutName, pointcutExpression).RegisterPointcut(aspect, pointcutName);
            }
            catch(Exception e)
            {
                throw new QueryParsingException(pointcutName, pointcutExpression, e);
            }
        }

        private static IPointcutProvider CreatePointcutProvider(string pointcutName, PointcutExpression pointcut)
        {
            var type = typeof(SelectMethodsAttribute).Assembly.GetType(typeof (SelectMethodsAttribute).Namespace + "." + pointcut.AttributeName + "Attribute");
            if (type == null)
                throw new QueryParsingException(pointcutName, pointcut, "Unrecognized pointcut attribute: " + pointcut.AttributeName);
            return (IPointcutProvider) Activator.CreateInstance(type, new object[] {pointcut.Saql});
        }
    }
}
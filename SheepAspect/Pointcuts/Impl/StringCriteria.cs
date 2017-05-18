using System;
using System.Collections.Generic;
using System.Linq;
using SheepAspect.Helpers;

namespace SheepAspect.Pointcuts.Impl
{
    public class StringCriteria: IWhereLiteral, IWhereAny<StringCriteria>
    {
        private readonly IList<Func<string, bool>> filters = new List<Func<string, bool>>();
        
        public void WhereLiteral(string value)
        {
            filters.Add(s => s.IsWildcardMatch(value));
        }

        public bool Match(string str)
        {
            return filters.All(f=> f(str));
        }

        public void WhereAny(params StringCriteria[] pointcuts)
        {
            filters.Add(s=> pointcuts.Any(c=> c.Match(s)));
        }

        public void WhereNot(StringCriteria criteria)
        {
            filters.Add(s=> !criteria.Match(s));
        }
    }
}
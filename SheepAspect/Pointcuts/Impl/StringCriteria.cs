using System;
using System.Collections.Generic;
using System.Linq;
using SheepAspect.Helpers;

namespace SheepAspect.Pointcuts.Impl
{
    public class StringCriteria: IWhereLiteral, IWhereAny<StringCriteria>
    {
        private readonly IList<Func<string, bool>> _filters = new List<Func<string, bool>>();
        
        public void WhereLiteral(string value)
        {
            _filters.Add(s => s.IsWildcardMatch(value));
        }

        public bool Match(string str)
        {
            return _filters.All(f=> f(str));
        }

        public void WhereAny(params StringCriteria[] pointcuts)
        {
            _filters.Add(s=> pointcuts.Any(c=> c.Match(s)));
        }

        public void WhereNot(StringCriteria criteria)
        {
            _filters.Add(s=> !criteria.Match(s));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace SheepAspect.Pointcuts.Impl
{
    public class MemberPointcut<TPointcut, TDefinition> : PointcutBase<TPointcut>, ITypePointcut
        where TPointcut : class, IMemberPointcut<TDefinition>
        where TDefinition : class, IMemberDefinition
    {
        private readonly TypePointcut typeFilter = new TypePointcut();
        private readonly IList<Func<TDefinition, bool>> filters = new List<Func<TDefinition, bool>>();

        public MemberPointcut()
        {
            WhereInType(t => !t.IsInterface);
        }

        public void Where(Func<TDefinition, bool> condition)
        {
            filters.Add(condition);
        }

        protected void WhereType(Func<TypeDefinition, bool> condition)
        {
            typeFilter.Where(condition);
        }

        public void FilterNot(MemberPointcut<TPointcut, TDefinition> pointcut)
        {
            if (pointcut.HasMemberFilter())
            {
                Where(m => !pointcut.MatchFull(m));
            }
            else
            {
                typeFilter.WhereNot(pointcut.typeFilter);
            }
        }

        private bool HasMemberFilter()
        {
            return filters.Any();
        }

        public override void WhereAny(Func<TPointcut[]> func)
        {
            typeFilter.WhereAny(func);
            Where(m =>
            {
                var pointcuts = func();
                return pointcuts.Length == 1 ? pointcuts[0].Match(m) : pointcuts.Any(p => p.MatchFull(m));
            });
        }

        public void WhereName(StringCriteria name)
        {
            Where(p => name.Match(p.Name));
        }

        protected void WhereInType(Func<TypeDefinition, bool> condition)
        {
            typeFilter.Where(condition);
        }

        public void WhereInType(TypePointcut crit)
        {
            typeFilter.WhereAny(crit);
        }

        #region Matcher

        public bool Match(TypeDefinition type)
        {
            return typeFilter.Match(type);
        }

        public bool MatchFull(TypeDefinition type)
        {
            return typeFilter.MatchFull(type);
        }

        public virtual bool Match(TDefinition def)
        {
            return def != null && filters.All(f => f(def));
        }

        public bool MatchFull(TDefinition def)
        {
            return def != null && MatchFull(def.DeclaringType) && Match(def);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using SheepAspect.Core;

namespace SheepAspect.Pointcuts.Impl
{
    public class MemberPointcut<TPointcut, TDefinition> : PointcutBase<TPointcut>, ITypePointcut
        where TPointcut : class, IMemberPointcut<TDefinition>
        where TDefinition : class, IMemberDefinition
    {
        private readonly TypePointcut _typeFilter = new TypePointcut();
        private readonly IList<Func<TDefinition, bool>> _filters = new List<Func<TDefinition, bool>>();

        public MemberPointcut()
        {
            WhereInType(t => !t.IsInterface);
        }

        public void Where(Func<TDefinition, bool> condition)
        {
            _filters.Add(condition);
        }

        protected void WhereType(Func<TypeDefinition, bool> condition)
        {
            _typeFilter.Where(condition);
        }

        public void FilterNot(MemberPointcut<TPointcut, TDefinition> pointcut)
        {
            if (pointcut.HasMemberFilter())
                Where(m => !pointcut.MatchFull(m));
            else
                _typeFilter.WhereNot(pointcut._typeFilter);
        }

        private bool HasMemberFilter()
        {
            return _filters.Any();
        }

        public override void WhereAny(Func<TPointcut[]> func)
        {
            _typeFilter.WhereAny(func);
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
            _typeFilter.Where(condition);
        }

        public void WhereInType(TypePointcut crit)
        {
            _typeFilter.WhereAny(crit);
        }

        #region Matcher

        public bool Match(TypeDefinition type)
        {
            return _typeFilter.Match(type);
        }

        public bool MatchFull(TypeDefinition type)
        {
            return _typeFilter.MatchFull(type);
        }

        public virtual bool Match(TDefinition def)
        {
            return def != null && _filters.All(f => f(def));
        }

        public bool MatchFull(TDefinition def)
        {
            return def != null && MatchFull(def.DeclaringType) && Match(def);
        }
        #endregion
    }
}
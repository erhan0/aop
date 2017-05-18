using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Linq;
using SheepAspect.Helpers;

namespace SheepAspect.Pointcuts.Impl
{
    public class PropertyPointcut : MemberPointcut<IPropertyPointcut, PropertyDefinition>, IPropertyPointcut
    {
        private readonly IList<Func<PropertyDefinition, bool>> propFilters = new List<Func<PropertyDefinition, bool>>();

        public void WhereNot(PropertyPointcut pointcut)
        {
            FilterNot(pointcut);
        }

        public void WhereType(TypePointcut crit)
        {
            Where(p => crit.MatchFull(p.PropertyType.Resolve()));
        }

        public virtual void WhereGetter()
        {
            throw new NotFiniteNumberException("Getter criteria is only supported if you set [SelectProperties(SelectAccessorMethods=true)]");
        }

        public virtual void WhereSetter()
        {
            throw new NotFiniteNumberException("Setter criteria is only supported if you set [SelectProperties(SelectAccessorMethods=true)]");
        }

        protected virtual IEnumerable<MethodDefinition> GetMethods(PropertyDefinition prop)
        {
            if (prop.GetMethod != null)
            {
                yield return prop.GetMethod;
            }

            if (prop.SetMethod != null)
            {
                yield return prop.SetMethod;
            }
        }

        public virtual void WhereHasCustomAttributeType(TypePointcut pointcut)
        {
            Where(p => p.CustomAttributes.Any(a => pointcut.MatchFull(a.AttributeType.Resolve())));
        }

        public virtual void WhereStatic()
        {
            Where(p=> GetMethods(p).All(m=> m.IsStatic));
        }

        public void WhereVirtual()
        {
            Where(p => GetMethods(p).All(m => m.IsVirtual));
        }

        public void WherePrivate()
        {
            Where(p => GetMethods(p).Any(m => m.IsPrivate));
        }

        public void WherePublic()
        {
            Where(p => GetMethods(p).All(m => m.IsPublic));
        }

        public void WhereProtected()
        {
            Where(p => GetMethods(p).Any(m => m.IsFamily) && GetMethods(p).All(m=> !m.IsPublic && !m.IsAssembly));
        }

        public void WhereInternal()
        {
            Where(p => GetMethods(p).Any(m => m.IsAssembly) && GetMethods(p).All(m => !m.IsPublic));
        }

        public void WhereLiteral(string value)
        {
            // TODO: Implement external DSL for method signature to improve performance
            Where(m => m.FullName.IsWildcardMatch(value));
        }
    }
}
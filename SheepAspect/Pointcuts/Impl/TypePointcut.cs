using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Linq;
using SheepAspect.Core;
using SheepAspect.Helpers;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Pointcuts.Impl
{
    public class TypePointcut : PointcutBase<ITypePointcut>, ITypePointcut, IWhereLiteral
    {
        private readonly IList<Func<TypeDefinition, bool>> _filters = new List<Func<TypeDefinition, bool>>();

        public void WhereNot(TypePointcut type)
        {
            Where(t=> !type.MatchFull(t));
        }

        public void WhereName(StringCriteria criteria)
        {
            Where(t => criteria.Match(t.Name));
        }

        public void WhereThisAspect(AspectDefinition aspect)
        {
            Where(t=> t.IsType(aspect.Type));
        }

        public void WhereHasCustomAttributeType(TypePointcut type)
        {
            Where(t=> t.CustomAttributes.Any(a=> type.MatchFull(a.AttributeType.Resolve())));
        }

        public void WhereAbstract()
        {
            Where(t=> t.IsAbstract);
        }

        public void WhereNamespace(StringCriteria criteria)
        {
            Where(t=> criteria.Match(t.Namespace));
        }

        public void WhereLiteral(string value)
        {
            // TODO: implement DSL here
            Where(t=> t.FullName.IsWildcardMatch(value));
        }

        public void WhereValueType()
        {
            Where(t=> t.IsValueType);
        }

        public void WhereHasMethod(MethodPointcut method)
        {
            Where(t=> method.Match(t) &&  t.Methods.Any(method.Match));
        }

        public void WhereHasProperty(PropertyPointcut property)
        {
            Where(t => property.Match(t) && t.Properties.Any(property.Match));
        }

        public void WhereHasPropertyMethod(PropertyMethodPointcut propertyMethod)
        {
            Where(t => propertyMethod.Match(t) && t.Methods.Any(propertyMethod.Match));
        }

        public void WhereAssignableToType(TypePointcut pointcut)
        {
            Where(t =>
            {
                if (t.Interfaces.Select(i=> i.Resolve()).Any(pointcut.MatchFull))
                {
                    return true;
                }

                while (true)
                {
                    if (pointcut.MatchFull(t))
                    {
                        return true;
                    }

                    if (t.BaseType == null)
                    {
                        return false;
                    }

                    t = t.BaseType.Resolve();
                }
            });
        }

        public void WhereImplementsType(TypePointcut pointcut)
        {
            Where(t => t.Interfaces.Select(i => i.Resolve()).Any(pointcut.MatchFull));
        }

        public override void WhereAny(Func<ITypePointcut[]> func)
        {
            Where(t=> func().Any(c=> c.Match(t)));
        }

        public void Where(Func<TypeDefinition, bool> condition)
        {
            _filters.Add(condition);
        }

        public bool Match(TypeDefinition type)
        {
            return _filters.All(f=> type!= null && f(type));
        }

        public bool MatchFull(TypeDefinition type)
        {
            return _filters.All(f => type != null && f(type));
        }
    }
}
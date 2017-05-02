using System.Linq;
using Mono.Cecil;
using SheepAspect.Helpers;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Pointcuts.Impl
{
    public class MethodPointcut : MemberPointcut<IMethodPointcut, MethodDefinition>, IMethodPointcut, IWhereLiteral
    {
        public MethodPointcut()
        {
            Where(m => !m.IsConstructor && !m.IsSpecialName);
        }

        public void WhereNot(MethodPointcut pointcut)
        {
            FilterNot(pointcut);
        }

        public void WhereVirtual()
        {
            Where(m=> m.IsVirtual);
        }

        public void WherePublic()
        {
            Where(m=> m.IsPublic);
        }

        public void WhereProtected()
        {
            Where(m => m.IsFamily);
        }

        public void WherePrivate()
        {
            Where(m => m.IsPrivate);
        }

        public void WhereInternal()
        {
            Where(m => m.IsAssembly);
        }

        public void WhereHasCustomAttributeType(TypePointcut type)
        {
            Where(m=> m.CustomAttributes.Any(a=> type.MatchFull(a.AttributeType.Resolve())));
        }

        public void WhereName(StringCriteria name)
        {
            Where(m=> name.Match(m.Name));
        }

        public void WhereReturnType(TypePointcut crit)
        {
            Where(m=> crit.MatchFull(m.ReturnType.Resolve()));
        }

        public void WhereReturnsVoid()
        {
            Where(m=> m.ReturnsVoid());
        }

        public void WhereStatic()
        {
            Where(m=> m.IsStatic);
        }

        public void WhereArgs(TypePointcut[] crits)
        {
            Where(m=>
                      {
                          if (crits.Length > m.Parameters.Count)
                              return false;

                          return !crits.Where((t, i) => !t.MatchFull(m.Parameters[i].ParameterType.Resolve())).Any();
                      });
        }

        public void WhereLiteral(string value)
        {
            // TODO: Implement external DSL for method signature to improve performance
            Where(m => m.FullName.IsWildcardMatch(value));
        }
    }
}
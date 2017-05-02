using System.Linq;
using Mono.Cecil;
using SheepAspect.Helpers;

namespace SheepAspect.Pointcuts.Impl
{
    public class ConstructorPointcut : MemberPointcut<IMethodPointcut, MethodDefinition>, IWhereLiteral, IConstructorPointcut
    {
        public ConstructorPointcut()
        {
            WhereType(t=> !t.IsInterface);
            Where(m => m.IsConstructor);
        }

        public void WhereVirtual()
        {
            Where(m => m.IsVirtual);
        }

        public void WherePublic()
        {
            Where(m => m.IsPublic);
        }

        public void WhereProtected()
        {
            Where(m => m.IsFamily);
        }

        public void WhereInternal()
        {
            Where(m => m.IsAssembly);
        }

        public void WherePrivate()
        {
            Where(m => m.IsPrivate);
        }

        public void WhereArgs(TypePointcut[] crits)
        {
            Where(m =>
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
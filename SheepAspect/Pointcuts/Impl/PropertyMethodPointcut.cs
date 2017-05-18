using Mono.Cecil;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Pointcuts.Impl
{
    public class PropertyMethodPointcut: PropertyPointcut, IMethodPointcut
    {
        private bool requireGetter;
        private bool requireSetter;

        public override void WhereGetter()
        {
            requireGetter = true;
        }
        public override void WhereSetter()
        {
            requireSetter = true;
        }

        public bool Match(MethodDefinition method)
        {
            return MatchAccessorType(method) && Match(method.GetProperty());
        }

        private bool MatchAccessorType(MethodDefinition method)
        {
            return (!requireGetter || method.IsGetter) && (!requireSetter || method.IsSetter);
        }

        public bool MatchFull(MethodDefinition method)
        {
            return MatchAccessorType(method) && MatchFull(method.GetProperty());
        }
    }
}
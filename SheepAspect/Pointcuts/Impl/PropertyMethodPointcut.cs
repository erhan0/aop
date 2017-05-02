using Mono.Cecil;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Pointcuts.Impl
{
    public class PropertyMethodPointcut: PropertyPointcut, IMethodPointcut
    {
        private bool _requireGetter;
        private bool _requireSetter;

        public override void WhereGetter()
        {
            _requireGetter = true;
        }
        public override void WhereSetter()
        {
            _requireSetter = true;
        }

        public bool Match(MethodDefinition method)
        {
            return MatchAccessorType(method) && Match(method.GetProperty());
        }

        private bool MatchAccessorType(MethodDefinition method)
        {
            return (!_requireGetter || method.IsGetter) && (!_requireSetter || method.IsSetter);
        }

        public bool MatchFull(MethodDefinition method)
        {
            return MatchAccessorType(method) && MatchFull(method.GetProperty());
        }
    }
}
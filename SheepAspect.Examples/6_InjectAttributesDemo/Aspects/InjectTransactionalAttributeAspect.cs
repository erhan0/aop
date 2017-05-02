using InjectAttributesDemo.Target;
using SheepAspect.Framework;

namespace InjectAttributesDemo.Aspects
{
    [SingletonAspect]
    public class InjectTransactionalAttributeAspect
    {
        [SelectMethods("Public & InType:Name:'*Service'")]
        public void OrderMethodsPointcut(){}

        [DeclareAttributes("OrderMethodsPointcut")]
        [Transactional(IsolationLevel = "READ COMMITTED", Scope = "RequiredNew")]
        public void AddTransactionalAttribute(){}
    }
}
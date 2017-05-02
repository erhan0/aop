using SheepAspect.Framework;

namespace MixinDemo
{
    [SingletonAspect]
    public class InjectTransactionalAttributeAspect
    {
        [SelectProperties("InType:'MixinDemo.OrderService'")]
        public void OrderMethodsPointcut(){}

        [DeclareAttributes("OrderMethodsPointcut")]
        [Transactional(IsolationLevel = "READ COMMITTED", Scope = "RequiredNew")]
        public void AddTransactionalAttribute(){}
    }
}
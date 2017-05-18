using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SheepAspect.Pointcuts.Impl
{
    public class CallMethodPointcut : InstructionPointcut<CallMethodPointcut>
    {
        private readonly MethodPointcut methodPointcut = new MethodPointcut();

        public CallMethodPointcut()
        {
            methodPointcut.Where(m => !m.Resolve().IsConstructor);
            Where(
                (m,i) =>
                (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt) &&
                methodPointcut.MatchFull(((MethodReference)i.Operand).Resolve()));
        }

        public void WhereMethod(MethodPointcut methodPointcut)
        {
            this.methodPointcut.WhereAny(methodPointcut);
        }
    }
}
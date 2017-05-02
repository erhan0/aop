using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SheepAspect.Pointcuts.Impl
{
    public class CallMethodPointcut : InstructionPointcut<CallMethodPointcut>
    {
        private readonly MethodPointcut _methodPointcut = new MethodPointcut();

        public CallMethodPointcut()
        {
            _methodPointcut.Where(m => !m.Resolve().IsConstructor);
            Where(
                (m,i) =>
                (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt) &&
                _methodPointcut.MatchFull(((MethodReference)i.Operand).Resolve()));
        }

        public void WhereMethod(MethodPointcut methodPointcut)
        {
            _methodPointcut.WhereAny(methodPointcut);
        }
    }
}
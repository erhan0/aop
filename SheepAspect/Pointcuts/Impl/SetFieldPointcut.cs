using Mono.Cecil;
using SheepAspect.Pointcuts.Descriptions;

namespace SheepAspect.Pointcuts.Impl
{
    public class SetFieldPointcut: InstructionPointcut<SetFieldPointcut>
    {
        private readonly FieldPointcut _fieldPointcut = new FieldPointcut();

        public SetFieldPointcut()
        {
            Where(
                (m,i) =>
                SetFieldDescription.IsValid(i) &&
                _fieldPointcut.MatchFull(((FieldReference)i.Operand).Resolve()));
        }

        public void WhereField(FieldPointcut fieldPointcut)
        {
            _fieldPointcut.WhereAny(fieldPointcut);
        }
    }
}
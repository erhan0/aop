using Mono.Cecil;
using SheepAspect.Pointcuts.Descriptions;

namespace SheepAspect.Pointcuts.Impl
{
    public class SetFieldPointcut: InstructionPointcut<SetFieldPointcut>
    {
        private readonly FieldPointcut fieldPointcut = new FieldPointcut();

        public SetFieldPointcut()
        {
            Where(
                (m,i) =>
                SetFieldDescription.IsValid(i) &&
                fieldPointcut.MatchFull(((FieldReference)i.Operand).Resolve()));
        }

        public void WhereField(FieldPointcut fieldPointcut)
        {
            this.fieldPointcut.WhereAny(fieldPointcut);
        }
    }
}
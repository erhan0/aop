using Mono.Cecil;
using SheepAspect.Pointcuts.Descriptions;

namespace SheepAspect.Pointcuts.Impl
{
    public class GetFieldPointcut : InstructionPointcut<GetFieldPointcut>
    {
        private readonly FieldPointcut fieldPointcut = new FieldPointcut();

        public GetFieldPointcut()
        {
            Where((m, i)=> GetFieldDescription.IsValid(i) && 
                fieldPointcut.MatchFull(((FieldReference) i.Operand).Resolve()));
        }

        public void WhereField(FieldPointcut fieldPointcut)
        {
            this.fieldPointcut.WhereAny(fieldPointcut);
        }
    }
}
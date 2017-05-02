using Mono.Cecil;
using SheepAspect.Pointcuts.Descriptions;

namespace SheepAspect.Pointcuts.Impl
{
    public class GetFieldPointcut : InstructionPointcut<GetFieldPointcut>
    {
        private readonly FieldPointcut _fieldPointcut = new FieldPointcut();

        public GetFieldPointcut()
        {
            Where((m, i)=> GetFieldDescription.IsValid(i) && 
                _fieldPointcut.MatchFull(((FieldReference) i.Operand).Resolve()));
        }

        public void WhereField(FieldPointcut fieldPointcut)
        {
            _fieldPointcut.WhereAny(fieldPointcut);
        }
    }
}
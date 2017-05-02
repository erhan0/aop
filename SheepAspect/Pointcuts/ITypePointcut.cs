using Mono.Cecil;
using SheepAspect.Core;

namespace SheepAspect.Pointcuts
{
    public interface ITypePointcut: IPointcut
    {
        bool Match(TypeDefinition type);
        bool MatchFull(TypeDefinition type);
    }
}
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SheepAspect.Core
{
    /// <summary>
    /// the Advice interface that all advices implement
    /// </summary>
    public interface IAdvice
    {
        IEnumerable<IPointcut> Pointcuts { get; }
        IEnumerable<IWeaver> GetWeavers(TypeDefinition type);
        IEnumerable<IWeaver> GetWeavers(MethodDefinition method);
        IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction);
        IEnumerable<IWeaver> GetWeavers(PropertyDefinition property);
        IEnumerable<IWeaver> GetWeavers(FieldDefinition field);
    }
}
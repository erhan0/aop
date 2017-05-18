using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SheepAspect.Pointcuts.Descriptions
{
    public interface IInstructionDescription
    {
        Instruction Instruction { get; }
        string Name { get; }
        Type JoinPointType { get; }
        void InitializeStaticJp(ILProcessor il);
        TypeReference[] ArgTypes { get; }
        TypeReference TargetType { get; }
        TypeReference ReturnType { get; }
    }
}
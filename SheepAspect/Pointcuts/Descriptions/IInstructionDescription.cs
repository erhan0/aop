using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SheepAspect.Pointcuts.Descriptions
{
    public interface IInstructionDescription
    {
        Instruction Instruction { get; }
        string GetName();
        Type GetJoinPointType();
        void InitializeStaticJp(ILProcessor il);
        TypeReference[] GetArgTypes();
        TypeReference GetTargetType();
        TypeReference GetReturnType();
    }
}
using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.Pointcuts.Descriptions
{
    public class GetFieldDescription: IInstructionDescription
    {
        public static bool IsValid(Instruction instruction)
        {
            return instruction.OpCode == OpCodes.Ldfld || instruction.OpCode == OpCodes.Ldsfld || instruction.OpCode == OpCodes.Ldflda;
        }

        private readonly FieldReference field;
        private Instruction instruction;

        public GetFieldDescription(Instruction instruction)
        {
            this.instruction = instruction;
            field = (FieldReference) instruction.Operand;
        }

        public Instruction Instruction
        {
            get { return instruction; }
        }

        public string Name { get { return "Field-Get"; } }

        public Type JoinPointType
        {
            get
            {
                return typeof(GetFieldJointPoint);
            }
        }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, field);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<FieldInfo>("GetFieldFromHandle", typeof(RuntimeFieldHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallFieldGet"));
        }

        public TypeReference[] ArgTypes
        {
            get
            {
                return new TypeReference[0];
            }
        }

        public TypeReference TargetType
        {
            get
            {
                return field.Resolve().IsStatic ? null : field.DeclaringType;
            }
        }

        public TypeReference ReturnType
        {
            get
            {
                return field.FieldType;
            }
        }
    }
}
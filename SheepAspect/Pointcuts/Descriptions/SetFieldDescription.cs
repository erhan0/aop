using System;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.Pointcuts.Descriptions
{
    public class SetFieldDescription: IInstructionDescription
    {
        public static bool IsValid(Instruction instruction)
        {
            return instruction.OpCode == OpCodes.Stfld || instruction.OpCode == OpCodes.Stsfld;
        }

        private readonly FieldReference field;
        private readonly Instruction instruction;

        public SetFieldDescription(Instruction instruction)
        {
            this.instruction = instruction;
            field = (FieldReference) instruction.Operand;
        }

        public Instruction Instruction
        {
            get { return instruction; }
        }

        public string Name { get { return "Field-Set"; } }

        public Type JoinPointType { get { return typeof(SetFieldJointPoint); } }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, field);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<FieldInfo>("GetFieldFromHandle", typeof(RuntimeFieldHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallFieldSet"));
        }

        public TypeReference[] ArgTypes
        {
            get
            {
                return new[] { field.FieldType };
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
                return null;
            }
        }
    }
}
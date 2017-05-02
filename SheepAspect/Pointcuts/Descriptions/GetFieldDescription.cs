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
        public static bool IsValid(Instruction i)
        {
            return i.OpCode == OpCodes.Ldfld || i.OpCode == OpCodes.Ldsfld || i.OpCode == OpCodes.Ldflda;
        }

        private readonly FieldReference _field;
        private Instruction _instruction;

        public GetFieldDescription(Instruction instruction)
        {
            _instruction = instruction;
            _field = (FieldReference) instruction.Operand;
        }

        public Instruction Instruction
        {
            get { return _instruction; }
        }

        public string GetName()
        {
            return "Field-Get";
        }

        public Type GetJoinPointType()
        {
            return typeof (GetFieldJointPoint);
        }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, _field);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<FieldInfo>("GetFieldFromHandle", typeof(RuntimeFieldHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallFieldGet"));
        }

        public TypeReference[] GetArgTypes()
        {
            return new TypeReference[0];
        }

        public TypeReference GetTargetType()
        {
            return _field.Resolve().IsStatic? null: _field.DeclaringType;
        }

        public TypeReference GetReturnType()
        {
            return _field.FieldType;
        }
    }
}
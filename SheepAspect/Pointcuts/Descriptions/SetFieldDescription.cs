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
        public static bool IsValid(Instruction i)
        {
            var t = i.OpCode == OpCodes.Stfld || i.OpCode == OpCodes.Stsfld;
            return t;
        }

        private readonly FieldReference _field;
        private readonly Instruction _instruction;

        public SetFieldDescription(Instruction instruction)
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
            return "Field-Set";
        }

        public Type GetJoinPointType()
        {
            return typeof(SetFieldJointPoint);
        }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, _field);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<FieldInfo>("GetFieldFromHandle", typeof(RuntimeFieldHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallFieldSet"));
        }

        public TypeReference[] GetArgTypes()
        {
            return new[] { _field.FieldType };
        }

        public TypeReference GetTargetType()
        {
            return _field.Resolve().IsStatic ? null : _field.DeclaringType;
        }

        public TypeReference GetReturnType()
        {
            return null;
        }
    }
}
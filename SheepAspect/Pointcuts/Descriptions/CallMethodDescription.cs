using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.Pointcuts.Descriptions
{
    public class CallMethodDescription: IInstructionDescription
    {
        public static bool IsValid(Instruction i)
        {
            return i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt || i.OpCode == OpCodes.Calli;
        }

        private readonly Instruction _instruction;
        private readonly MethodReference _targetMethod;
        public CallMethodDescription(Instruction instruction)
        {
            _instruction = instruction;
            _targetMethod = (MethodReference)instruction.Operand;
        }

        public string GetName()
        {
            return "Call Method";
        }

        public Instruction Instruction
        {
            get { return _instruction; }
        }

        public Type GetJoinPointType()
        {
            return typeof (CallMethodJointPoint);
        }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, _targetMethod);
            il.Append(OpCodes.Ldtoken, _targetMethod.DeclaringType);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallMethod"));
        }

        public TypeReference[] GetArgTypes()
        {
            return _targetMethod.Parameters.Select(p=> p.ParameterType).ToArray();
        }

        public TypeReference GetTargetType()
        {
            return _targetMethod.Resolve().IsStatic?null: _targetMethod.DeclaringType;
        }

        public TypeReference GetReturnType()
        {
            return _targetMethod.ReturnsVoid()?null: _targetMethod.ReturnType;
        }
    }
}
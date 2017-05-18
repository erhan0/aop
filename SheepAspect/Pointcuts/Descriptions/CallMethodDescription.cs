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
        public static bool IsValid(Instruction instruction)
        {
            return instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt || instruction.OpCode == OpCodes.Calli;
        }

        private readonly Instruction instruction;
        private readonly MethodReference targetMethod;
        public CallMethodDescription(Instruction instruction)
        {
            this.instruction = instruction;
            targetMethod = (MethodReference)instruction.Operand;
        }

        public string Name { get { return "Call Method"; } }

        public Instruction Instruction
        {
            get { return instruction; }
        }

        public Type JoinPointType
        {
            get
            {
                return typeof(CallMethodJointPoint);
            }
        }

        public void InitializeStaticJp(ILProcessor il)
        {
            il.Append(OpCodes.Ldtoken, targetMethod);
            il.Append(OpCodes.Ldtoken, targetMethod.DeclaringType);
            il.Append(OpCodes.Call,
                      il.Body.Method.Module.ImportMethod<MethodBase>("GetMethodFromHandle", typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle)));

            il.Append(OpCodes.Call, il.Body.Method.Module.ImportMethod<JointPointBase.StaticPart>("ForCallMethod"));
        }

        public TypeReference[] ArgTypes
        {
            get
            {
                return targetMethod.Parameters.Select(p => p.ParameterType).ToArray();
            }
        }

        public TypeReference TargetType
        {
            get
            {
                return targetMethod.Resolve().IsStatic ? null : targetMethod.DeclaringType;
            }
        }

        public TypeReference ReturnType
        {
            get
            {
                return targetMethod.ReturnsVoid() ? null : targetMethod.ReturnType;
            }
        }
    }
}
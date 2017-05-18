using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Pointcuts.Descriptions;

namespace SheepAspect.AroundAdvising
{
    public class AroundInstructionWeaver: AroundWeaverBase
    {
        protected readonly Instruction instruction;
        private readonly IInstructionDescription description;

        public AroundInstructionWeaver(IInstructionDescription description, MethodDefinition method, AroundAdvice advice, int priority)
            : base(method, advice, priority)
        {
            instruction = description.Instruction;
            originalOperand = description.Instruction.Operand;
            this.description = description;
        }

        private TypeReference returnType;
        private TypeReference[] argTypes;
        private bool returnsVoid;
        private TypeReference targetType;
        private Instruction ccInstruction;
        private readonly object originalOperand;
        private bool isPreviouslyWeaved;
        
        protected override void Init()
        {
            isPreviouslyWeaved = instruction.Operand != originalOperand;
            argTypes = description.ArgTypes;
            returnType = description.ReturnType;
            returnsVoid = returnType == null;
            targetType = description.TargetType;

            ccInstruction = Instruction.Create(OpCodes.Nop);
            ccInstruction.OpCode = instruction.OpCode;
            ccInstruction.Operand = instruction.Operand;
        }

        protected override string AdviceTypeName { get { return "Around " + description.Name; } }

        protected override Type JoinPointType { get { return description.JoinPointType; } }

        protected override void AppendInitializeStaticJp(ILProcessor il)
        {
            if (originalOperand is MemberReference member)
            {
                member.TransferGenerics(JpGenericParamMap);
            }

            description.InitializeStaticJp(il);
        }

        protected override void CallbackMethodBody(ILProcessor il, ParameterDefinition thisInstance, ParameterDefinition target, ParameterDefinition args)
        {
            if(targetType != null)
            {
                il.Append(OpCodes.Ldarg, target);
            }

            for (var i = 0; i < argTypes.Length; i++)
            {
                il.Append(OpCodes.Ldarg, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldelem_Ref);
                var type = argTypes[i];
                if (type.IsValueType)
                {
                    il.Append(OpCodes.Unbox_Any, Module.Import(type));
                }
            }

            // Calling another dispatcher, which requires extra arg for thisInstance
            if (!method.IsStatic && isPreviouslyWeaved)
            {
                il.Append(OpCodes.Ldarg, thisInstance);
                if (method.DeclaringType.IsValueType)
                {
                    il.Append(OpCodes.Box, method.DeclaringType);
                }
            }

            il.Append(ccInstruction);

            if (returnsVoid)
            {
                il.Append(OpCodes.Ldnull);
            }
            else if (returnType.IsValueType)
            {
                il.Append(OpCodes.Box, Module.Import(returnType));
            }

            il.Append(OpCodes.Ret);
        }

        protected override void WeaveOriginalTarget()
        {
            var index = method.Body.Instructions.IndexOf(instruction);
            if(index == -1)
            {
                throw new BytecodeWeavingException("Instruction not found '{0}' in method '{1}'".FormatWith(instruction, method));
            }

            var dispatcher = new MethodDefinition("Dispatcher", MethodAttributes.Static | MethodAttributes.Public,
                                                  returnType?? Module.Import(typeof(void)));
            jpStaticClass.Methods.Add(dispatcher);

            var il = dispatcher.Body.GetILProcessor();
            il.Append(OpCodes.Nop);

            if(targetType != null)
            {
                var target = new ParameterDefinition(targetType);
                dispatcher.Parameters.Add(target);
                il.Append(OpCodes.Ldarg, target);
                if (targetType.IsValueType)
                {
                    il.Append(OpCodes.Box, targetType);
                }
            }
            else
            {
                il.Append(OpCodes.Ldnull);
            }

            var args = dispatcher.AddLocal(typeof(object[]));
            var typeOfObject = Module.Import(typeof(object));
            il.Append(OpCodes.Ldc_I4, argTypes.Length);
            il.Append(OpCodes.Newarr, typeOfObject);
            il.Append(OpCodes.Stloc, args);
                
            for (var i = 0; i < argTypes.Length; i++)
            {
                var arg = new ParameterDefinition(argTypes[i]);
                dispatcher.Parameters.Add(arg);

                il.Append(OpCodes.Ldloc, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldarg, arg);
                if (argTypes[i].IsValueType)
                {
                    il.Append(OpCodes.Box, argTypes[i]);
                }

                il.Append(OpCodes.Stelem_Ref);
            }

            if(!method.IsStatic)
            {
                var thisType = method.DeclaringType.MakeGenerics(JpThisGenericParams);
                var arg = new ParameterDefinition("sac$this", ParameterAttributes.None, thisType);
                dispatcher.Parameters.Add(arg);
                il.Append(OpCodes.Ldarg, arg);
                if (thisType.IsValueType)
                {
                    il.Append(OpCodes.Box, thisType);
                }
            }
            else
            {
                il.Append(OpCodes.Ldnull);
            }
            
            AppendCallDispatch(il, args, jpStaticClass.MakeGenericSelf());

            if (returnsVoid)
            {
                il.Append(OpCodes.Pop);
            }
            else if (returnType.IsValueType)
            {
                il.Append(OpCodes.Unbox_Any, Module.Import(returnType));
            }

            il.Append(OpCodes.Ret);

            // Dispatcher requires extra param (ThisInstance), but previous weaver might have been here
            if (!method.IsStatic && !isPreviouslyWeaved)
            {
                method.Body.GetILProcessor().InsertBefore(instruction, Instruction.Create(OpCodes.Ldarg_0));
            }

            instruction.OpCode = OpCodes.Call;
            instruction.Operand = dispatcher.MakeHostInstanceGeneric(GetRefThisToJpStatic());
        }
    }
}
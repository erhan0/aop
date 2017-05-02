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
        protected readonly Instruction Instruction;
        private readonly IInstructionDescription _description;

        public AroundInstructionWeaver(IInstructionDescription description, MethodDefinition method, AroundAdvice advice, int priority)
            : base(method, advice, priority)
        {
            Instruction = description.Instruction;
            _originalOperand = description.Instruction.Operand;
            _description = description;
        }

        private TypeReference _returnType;
        private TypeReference[] _argTypes;
        private bool _returnsVoid;
        private TypeReference _targetType;
        private Instruction _ccInstruction;
        private readonly object _originalOperand;

        private bool _isPreviouslyWeaved;
        
        protected override void Init()
        {
            _isPreviouslyWeaved = Instruction.Operand != _originalOperand;
            _argTypes = _description.GetArgTypes();
            _returnType = _description.GetReturnType();
            _returnsVoid = _returnType == null;
            _targetType = _description.GetTargetType();

            _ccInstruction = Instruction.Create(OpCodes.Nop);
            _ccInstruction.OpCode = Instruction.OpCode;
            _ccInstruction.Operand = Instruction.Operand;
        }

        protected override string GetAdviceTypeName()
        {
            return "Around " + _description.GetName();
        }

        protected override Type GetJoinPointType()
        {
            return _description.GetJoinPointType();
        }

        protected override void AppendInitializeStaticJp(ILProcessor il)
        {
            var member = _originalOperand as MemberReference;
            if(member != null)
                member.TransferGenerics(JpGenericParamMap);
            _description.InitializeStaticJp(il);
        }

        protected override void CallbackMethodBody(ILProcessor il, ParameterDefinition thisInstance, ParameterDefinition target, ParameterDefinition args)
        {
            if(_targetType != null)
                il.Append(OpCodes.Ldarg, target);

            for (var i = 0; i < _argTypes.Length; i++)
            {
                il.Append(OpCodes.Ldarg, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldelem_Ref);
                var type = _argTypes[i];
                if (type.IsValueType)
                    il.Append(OpCodes.Unbox_Any, Module.Import(type));
            }

            // Calling another dispatcher, which requires extra arg for thisInstance
            if (!Method.IsStatic && _isPreviouslyWeaved)
            {
                il.Append(OpCodes.Ldarg, thisInstance);
                if (Method.DeclaringType.IsValueType)
                    il.Append(OpCodes.Box, Method.DeclaringType);
            }

            il.Append(_ccInstruction);

            if (_returnsVoid)
                il.Append(OpCodes.Ldnull);
            else if (_returnType.IsValueType)
                il.Append(OpCodes.Box, Module.Import(_returnType));
            il.Append(OpCodes.Ret);
        }

        protected override void WeaveOriginalTarget()
        {
            var index = Method.Body.Instructions.IndexOf(Instruction);
            if(index == -1)
                throw new BytecodeWeavingException("Instruction not found '{0}' in method '{1}'".FormatWith(Instruction, Method));

            var dispatcher = new MethodDefinition("Dispatcher", MethodAttributes.Static | MethodAttributes.Public,
                                                  _returnType?? Module.Import(typeof(void)));
            JpStaticClass.Methods.Add(dispatcher);

            var il = dispatcher.Body.GetILProcessor();
            il.Append(OpCodes.Nop);

            if(_targetType != null)
            {
                var target = new ParameterDefinition(_targetType);
                dispatcher.Parameters.Add(target);
                il.Append(OpCodes.Ldarg, target);
                if (_targetType.IsValueType)
                    il.Append(OpCodes.Box, _targetType);
            }
            else
                il.Append(OpCodes.Ldnull);

            var args = dispatcher.AddLocal(typeof(object[]));
            var typeOfObject = Module.Import(typeof(object));
            il.Append(OpCodes.Ldc_I4, _argTypes.Length);
            il.Append(OpCodes.Newarr, typeOfObject);
            il.Append(OpCodes.Stloc, args);
                
            for (var i = 0; i < _argTypes.Length; i++)
            {
                var arg = new ParameterDefinition(_argTypes[i]);
                dispatcher.Parameters.Add(arg);

                il.Append(OpCodes.Ldloc, args);
                il.Append(OpCodes.Ldc_I4, i);
                il.Append(OpCodes.Ldarg, arg);
                if (_argTypes[i].IsValueType)
                    il.Append(OpCodes.Box, _argTypes[i]);
                il.Append(OpCodes.Stelem_Ref);
            }

            if(!Method.IsStatic)
            {
                var thisType = Method.DeclaringType.MakeGenerics(JpThisGenericParams);
                var arg = new ParameterDefinition("sac$this", ParameterAttributes.None, thisType);
                dispatcher.Parameters.Add(arg);
                il.Append(OpCodes.Ldarg, arg);
                if (thisType.IsValueType)
                    il.Append(OpCodes.Box, thisType);
            }
            else
            {
                il.Append(OpCodes.Ldnull);
            }
            
            AppendCallDispatch(il, args, JpStaticClass.MakeGenericSelf());

            if (_returnsVoid)
                il.Append(OpCodes.Pop);
            else if (_returnType.IsValueType)
                il.Append(OpCodes.Unbox_Any, Module.Import(_returnType));

            il.Append(OpCodes.Ret);

            // Dispatcher requires extra param (ThisInstance), but previous weaver might have been here
            if (!Method.IsStatic && !_isPreviouslyWeaved)
                Method.Body.GetILProcessor().InsertBefore(Instruction, Instruction.Create(OpCodes.Ldarg_0));
            
            Instruction.OpCode = OpCodes.Call;
            Instruction.Operand = dispatcher.MakeHostInstanceGeneric(GetRefThisToJpStatic());
        }
    }
}
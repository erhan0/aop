using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;
using SheepAspect.Core;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Pointcuts.Descriptions;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.LifecycleAdvising
{
    public class PerFlowLifecycleWeaver : MethodWeaverBase
    {
        private readonly ILProcessor il;
        private readonly Instruction _instruction;
        private readonly TypeReference _aspectType;

        private IList<Instruction> _beforeInstructions = new List<Instruction>();
        private IList<Instruction> _affectedInstructions = new List<Instruction>();
        private IList<Instruction> _afterInstructions = new List<Instruction>();
        private IInstructionDescription _iDescriptor;

        /// <summary>
        /// Weavers with lower priority values will get processed earlier during compilation
        /// This is useful to ensure certain weavers only get executed after all others, hence ensuring it will not get overruled by accident
        /// Priority value of FlowAspectLifecycleWeaver is 900, so it will be executed later than other MethodWeaverBase (by default: 100)
        /// </summary>
        public override int Priority
        {
            get { return 900; }
        }

        public PerFlowLifecycleWeaver(MethodDefinition targetMethod, Instruction instruction, Type aspectType) : base(targetMethod)
        {
            _instruction = instruction;
            _aspectType = Module.Import(aspectType);
            il = targetMethod.Body.GetILProcessor();
        }

        public override void Weave()
        {
            if(_instruction != null)
                _iDescriptor = InstructionDescriptor.Instance.GetDescription(_instruction);
            
            var start = il.Create(OpCodes.Nop);
            var startFinally = il.Create(OpCodes.Nop);
            var end = il.Create(OpCodes.Nop);

            SplitInstructions();
            il.AppendAll(_beforeInstructions);
            AppendProlog();
            il.Append(start);
            il.AppendAll(_affectedInstructions);
            il.Append(OpCodes.Leave_S, end);
            il.Append(startFinally);
            AppendEpilog();
            il.Append(OpCodes.Endfinally);
            il.Append(end);

            il.AppendAll(_afterInstructions);

            var handler = new ExceptionHandler(ExceptionHandlerType.Finally)
                {
                    TryStart = start,
                    TryEnd = startFinally,
                    HandlerStart = startFinally,
                    HandlerEnd = end
                };
            Method.Body.ExceptionHandlers.Add(handler);
        }

        private TypeReference GetReturnType()
        {
            if (_instruction == null)
                return Method.ReturnsVoid()?null:Method.ReturnType;

            return _iDescriptor.GetReturnType();
        }

        private void SplitInstructions()
        {
            _affectedInstructions = il.Body.Instructions.ToList();
            il.Body.Instructions.Clear();

            if(_instruction == null)
            {
                var first = _affectedInstructions.First();
                var last = _affectedInstructions.Last(x=> x.OpCode == OpCodes.Ret);
                
                if (first.OpCode == OpCodes.Nop)
                {
                    _beforeInstructions.Add(first);
                    _affectedInstructions.RemoveAt(0);
                }
                if(last.OpCode == OpCodes.Ret)
                {
                    _afterInstructions.Add(last);
                    _affectedInstructions.Remove(last);
                }
            }
            else
            {
                var index = _affectedInstructions.IndexOf(_instruction);
                _beforeInstructions = _affectedInstructions.Take(index).ToList();
                _afterInstructions = _affectedInstructions.Skip(index + 1).ToList();

                _affectedInstructions.Clear();
                foreach (var argLoc in _iDescriptor.GetArgTypes().Select(argType => Method.AddLocal(argType)).Reverse())
                {
                    _beforeInstructions.Add(il.Create(OpCodes.Stloc, argLoc));
                    _affectedInstructions.Insert(0, il.Create(OpCodes.Ldloc, argLoc));
                }
                var targetType = _iDescriptor.GetTargetType();
                if(targetType != null)
                {
                    var targetLoc = Method.AddLocal(targetType);
                    _beforeInstructions.Add(il.Create(OpCodes.Stloc, targetLoc));
                    _affectedInstructions.Insert(0, il.Create(OpCodes.Ldloc, targetLoc));
                }
                
                _affectedInstructions.Add(_instruction);
            }

            var retType = GetReturnType();
            if (retType != null)
            {
                var retVal = Method.AddLocal(retType);
                _affectedInstructions.Add(il.Create(OpCodes.Stloc, retVal));
                _afterInstructions.Insert(0, il.Create(OpCodes.Ldloc, retVal));
            }
            
        }

        public void AppendProlog()
        {
            il.Append(OpCodes.Ldtoken, Method.Module.Import(_aspectType));
            il.Append(OpCodes.Call, Method.Module.ImportMethod<Type>("GetTypeFromHandle"));
            il.Append(OpCodes.Call, Method.Module.ImportMethod(typeof(PerCFlowAspectLifecycle), "Push"));
        }

        public void AppendEpilog()
        {
            il.Append(OpCodes.Ldtoken, Method.Module.Import(_aspectType));
            il.Append(OpCodes.Call, Method.Module.ImportMethod<Type>("GetTypeFromHandle"));
            il.Append(OpCodes.Call, Method.Module.ImportMethod(typeof(PerCFlowAspectLifecycle), "Pop"));
        }
    }
}
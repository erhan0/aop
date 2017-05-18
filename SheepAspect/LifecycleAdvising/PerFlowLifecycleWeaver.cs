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
        private readonly Instruction instruction;
        private readonly TypeReference _aspectType;

        private IList<Instruction> beforeInstructions = new List<Instruction>();
        private IList<Instruction> affectedInstructions = new List<Instruction>();
        private IList<Instruction> afterInstructions = new List<Instruction>();
        private IInstructionDescription iDescriptor;

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
            this.instruction = instruction;
            _aspectType = Module.Import(aspectType);
            il = targetMethod.Body.GetILProcessor();
        }

        public override void Weave()
        {
            if(instruction != null)
            {
                iDescriptor = InstructionDescriptor.Instance.GetDescription(instruction);
            }

            var start = il.Create(OpCodes.Nop);
            var startFinally = il.Create(OpCodes.Nop);
            var end = il.Create(OpCodes.Nop);

            SplitInstructions();
            il.AppendAll(beforeInstructions);
            AppendProlog();
            il.Append(start);
            il.AppendAll(affectedInstructions);
            il.Append(OpCodes.Leave_S, end);
            il.Append(startFinally);
            AppendEpilog();
            il.Append(OpCodes.Endfinally);
            il.Append(end);

            il.AppendAll(afterInstructions);

            var handler = new ExceptionHandler(ExceptionHandlerType.Finally)
                {
                    TryStart = start,
                    TryEnd = startFinally,
                    HandlerStart = startFinally,
                    HandlerEnd = end
                };
            method.Body.ExceptionHandlers.Add(handler);
        }

        private TypeReference GetReturnType()
        {
            if (instruction == null)
            {
                return method.ReturnsVoid()?null:method.ReturnType;
            }

            return iDescriptor.ReturnType;
        }

        private void SplitInstructions()
        {
            affectedInstructions = il.Body.Instructions.ToList();
            il.Body.Instructions.Clear();

            if(instruction == null)
            {
                var first = affectedInstructions.First();
                var last = affectedInstructions.Last(x=> x.OpCode == OpCodes.Ret);
                
                if (first.OpCode == OpCodes.Nop)
                {
                    beforeInstructions.Add(first);
                    affectedInstructions.RemoveAt(0);
                }
                if(last.OpCode == OpCodes.Ret)
                {
                    afterInstructions.Add(last);
                    affectedInstructions.Remove(last);
                }
            }
            else
            {
                var index = affectedInstructions.IndexOf(instruction);
                beforeInstructions = affectedInstructions.Take(index).ToList();
                afterInstructions = affectedInstructions.Skip(index + 1).ToList();

                affectedInstructions.Clear();
                foreach (var argLoc in iDescriptor.ArgTypes.Select(argType => method.AddLocal(argType)).Reverse())
                {
                    beforeInstructions.Add(il.Create(OpCodes.Stloc, argLoc));
                    affectedInstructions.Insert(0, il.Create(OpCodes.Ldloc, argLoc));
                }
                var targetType = iDescriptor.TargetType;
                if(targetType != null)
                {
                    var targetLoc = method.AddLocal(targetType);
                    beforeInstructions.Add(il.Create(OpCodes.Stloc, targetLoc));
                    affectedInstructions.Insert(0, il.Create(OpCodes.Ldloc, targetLoc));
                }
                
                affectedInstructions.Add(instruction);
            }

            var retType = GetReturnType();
            if (retType != null)
            {
                var retVal = method.AddLocal(retType);
                affectedInstructions.Add(il.Create(OpCodes.Stloc, retVal));
                afterInstructions.Insert(0, il.Create(OpCodes.Ldloc, retVal));
            }
            
        }

        public void AppendProlog()
        {
            il.Append(OpCodes.Ldtoken, method.Module.Import(_aspectType));
            il.Append(OpCodes.Call, method.Module.ImportMethod<Type>("GetTypeFromHandle"));
            il.Append(OpCodes.Call, method.Module.ImportMethod(typeof(PerCFlowAspectLifecycle), "Push"));
        }

        public void AppendEpilog()
        {
            il.Append(OpCodes.Ldtoken, method.Module.Import(_aspectType));
            il.Append(OpCodes.Call, method.Module.ImportMethod<Type>("GetTypeFromHandle"));
            il.Append(OpCodes.Call, method.Module.ImportMethod(typeof(PerCFlowAspectLifecycle), "Pop"));
        }
    }
}
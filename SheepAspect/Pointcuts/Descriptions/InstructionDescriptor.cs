using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using System.Linq;
using SheepAspect.Exceptions;

namespace SheepAspect.Pointcuts.Descriptions
{
    public class InstructionDescriptor
    {
        public static InstructionDescriptor Instance { get; set; }

        private readonly IList<Tuple<Predicate<Instruction>, Func<Instruction, IInstructionDescription>>> _factories = new List<Tuple<Predicate<Instruction>, Func<Instruction, IInstructionDescription>>>();

        static InstructionDescriptor()
        {
            Instance = new InstructionDescriptor();
        }

        public InstructionDescriptor()
        {
            Register(CallMethodDescription.IsValid, i=> new CallMethodDescription(i));
            Register(GetFieldDescription.IsValid, i => new GetFieldDescription(i));
            Register(SetFieldDescription.IsValid, i => new SetFieldDescription(i));
        }

        public virtual IInstructionDescription GetDescription(Instruction i)
        {
            var val = _factories.FirstOrDefault(kv => kv.Item1(i));
            if (val == null)
                throw new UnrecognizedInstructionException(i);
            return val.Item2(i);
        }

        public void Register(Predicate<Instruction> condition, Func<Instruction, IInstructionDescription> factory)
        {
            _factories.Add(new Tuple<Predicate<Instruction>, Func<Instruction, IInstructionDescription>>(condition, factory));
        }
    }
}
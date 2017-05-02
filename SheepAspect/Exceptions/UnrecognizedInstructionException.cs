using Mono.Cecil.Cil;
using SheepAspect.Helpers;

namespace SheepAspect.Exceptions
{
    public class UnrecognizedInstructionException: SheepAspectException
    {
        public UnrecognizedInstructionException(Instruction i) : base("Instruction not recognized by InstructionDescriptor: '{0}'".FormatWith(i))
        {
        }
    }
}
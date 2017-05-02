using System.Collections.Generic;
using Mono.Cecil.Cil;

namespace SheepAspect.Helpers.CecilExtensions
{
    public static class ILProcessorExtensions
    {
        public static void AppendAll(this ILProcessor il, IEnumerable<Instruction> instructions)
        {
            foreach(var i in instructions)
                il.Append(i);
        }

        public static Instruction Append(this ILProcessor il, OpCode opCode)
        {
            var i = il.Create(opCode);
            il.Append(i);
            return i;
        }
        public static Instruction Append(this ILProcessor il, OpCode opCode, dynamic arg)
        {
            var i = il.Create(opCode, arg);
            il.Append(i);
            return i;
        }
    }
}
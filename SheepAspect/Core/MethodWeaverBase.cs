using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Core
{
    public abstract class MethodWeaverBase : IWeaver
    {
        protected MethodDefinition Method;

        protected MethodWeaverBase(MethodDefinition method)
        {
            Method = method;
        }

        public abstract int Priority { get; }
        public abstract void Weave();
        public ModuleDefinition Module
        {
            get { return Method.Module; }
        }

        protected Instruction LdThis(ILProcessor il)
        {
            if (Method.IsStatic)
                return il.Append(OpCodes.Ldnull);
            return il.Append(OpCodes.Ldarg_0);
        }
    }
}
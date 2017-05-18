using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.Core
{
    public abstract class MethodWeaverBase : IWeaver
    {
        protected MethodDefinition method;

        protected MethodWeaverBase(MethodDefinition method)
        {
            this.method = method;
        }

        public abstract int Priority { get; }
        public abstract void Weave();
        public ModuleDefinition Module
        {
            get { return method.Module; }
        }

        protected Instruction LdThis(ILProcessor il)
        {
            if (method.IsStatic)
            {
                return il.Append(OpCodes.Ldnull);
            }
            return il.Append(OpCodes.Ldarg_0);
        }
    }
}
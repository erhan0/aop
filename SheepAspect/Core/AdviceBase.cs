using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Exceptions;

namespace SheepAspect.Core
{
    public abstract class AdviceBase : IAdvice
    {
        public IEnumerable<IPointcut> Pointcuts { get; private set; }

        protected AdviceBase(IEnumerable<IPointcut> pointcuts)
        {
            if (pointcuts == null)
                throw new ArgumentNullException("pointcut");
            
            Pointcuts = pointcuts;
        }

        public abstract string GetFullName();

        public virtual IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, GetFullName(), GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            throw new UnsupportedPointcutToAdviseException(method, GetFullName(), GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            throw new UnsupportedPointcutToAdviseException(method, instruction, GetFullName(), GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            throw new UnsupportedPointcutToAdviseException(property, GetFullName(), GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(FieldDefinition field)
        {
            throw new UnsupportedPointcutToAdviseException(field, GetFullName(), GetType().Name);
        }
    }
}
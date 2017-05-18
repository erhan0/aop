using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Exceptions;

namespace SheepAspect.Core
{
    /// <summary>
    /// Abstract advice class that all advices extend
    /// </summary>
    public abstract class AdviceBase : IAdvice
    {
        public IEnumerable<IPointcut> Pointcuts { get; private set; }
        public abstract string FullName { get; }


        protected AdviceBase(IEnumerable<IPointcut> pointcuts)
        {
            Pointcuts = pointcuts ?? throw new ArgumentNullException("pointcut");
        }

        /// <summary>
        /// Getting weavers
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, FullName, GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            throw new UnsupportedPointcutToAdviseException(method, FullName, GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            throw new UnsupportedPointcutToAdviseException(method, instruction, FullName, GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            throw new UnsupportedPointcutToAdviseException(property, FullName, GetType().Name);
        }

        public virtual IEnumerable<IWeaver> GetWeavers(FieldDefinition field)
        {
            throw new UnsupportedPointcutToAdviseException(field, FullName, GetType().Name);
        }
    }
}
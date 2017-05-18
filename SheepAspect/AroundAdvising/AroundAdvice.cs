using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Helpers;
using SheepAspect.Pointcuts.Descriptions;
using SheepAspect.Helpers.CecilExtensions;

namespace SheepAspect.AroundAdvising
{
    /// <summary>
    /// Around advice
    /// </summary>
    public class AroundAdvice : AdviceBase
    {
        public const int PRIORITY = 100;

        public MethodInfo AdviceMethod { get; set; }
        
        public AroundAdvice(IEnumerable<IPointcut> pointcuts, MethodInfo method)
            : base(pointcuts)
        {
            AdviceMethod = method ?? throw new ArgumentNullException("method");
            Priority = PRIORITY;
        }

        public int Priority { get; set; }

        /// <summary>
        /// Returns the full name
        /// </summary>
        /// <returns>The full name</returns>
        public override string FullName
        {
            get
            {
                return "Around/{0}::{1}".FormatWith(AdviceMethod.ReflectedType.FullName, AdviceMethod.Name);
            }
        }
 
        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, FullName, "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            if(property.GetMethod != null)
            {
                yield return new AroundPropertyGetWeaver(property, this, Priority);
            }

            if (property.SetMethod != null)
            {
                yield return new AroundPropertySetWeaver(property, this, Priority);
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(FieldDefinition field)
        {
            throw new UnsupportedPointcutToAdviseException(field, FullName, "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            if(method.IsGetter)
            {
                yield return new AroundPropertyGetWeaver(method.GetProperty(), this, Priority);
            }
            else if(method.IsSetter)
            {
                yield return new AroundPropertySetWeaver(method.GetProperty(), this, Priority);
            }
            else
            {
                yield return new AroundMethodWeaver(method, this, Priority);
            }
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            yield return new AroundInstructionWeaver(InstructionDescriptor.Instance.GetDescription(instruction), method, this, Priority);
        }
    }
}
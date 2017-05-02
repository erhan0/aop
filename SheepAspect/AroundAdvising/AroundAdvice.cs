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
    public class AroundAdvice : AdviceBase
    {
        public const int PRIORITY = 100;

        public MethodInfo AdviceMethod { get; set; }
        
        public AroundAdvice(IEnumerable<IPointcut> pointcuts, MethodInfo method)
            : base(pointcuts)
        {
            if(method == null)
                throw new ArgumentNullException("method");

            AdviceMethod = method;
            Priority = PRIORITY;
        }

        public int Priority { get; set; }

        public override string GetFullName()
        {
            return "Around/{0}::{1}".FormatWith(AdviceMethod.ReflectedType.FullName, AdviceMethod.Name);
        }

        //public override IEnumerable<IBytecodeWeaver> GetWeavers(IEnumerable<TypeDefinition> allTypes)
        //{
        //    var types = allTypes.Where(Pointcut.Match).ToArray();
        //    return types.SelectMany(t => Pointcut.GetAroundAdviceWeavers(t, this));
        //}
        public override IEnumerable<IWeaver> GetWeavers(TypeDefinition type)
        {
            throw new UnsupportedPointcutToAdviseException(type, GetFullName(), "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(PropertyDefinition property)
        {
            if(property.GetMethod != null)
                yield return new AroundPropertyGetWeaver(property, this, Priority);
            if (property.SetMethod != null)
                yield return new AroundPropertySetWeaver(property, this, Priority);
        }

        public override IEnumerable<IWeaver> GetWeavers(FieldDefinition field)
        {
            throw new UnsupportedPointcutToAdviseException(field, GetFullName(), "Around");
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method)
        {
            if(method.IsGetter)
                yield return new AroundPropertyGetWeaver(method.GetProperty(), this, Priority);
            else if(method.IsSetter)
                yield return new AroundPropertySetWeaver(method.GetProperty(), this, Priority);
            else
                yield return new AroundMethodWeaver(method, this, Priority);
        }

        public override IEnumerable<IWeaver> GetWeavers(MethodDefinition method, Instruction instruction)
        {
            yield return
                new AroundInstructionWeaver(InstructionDescriptor.Instance.GetDescription(instruction), method, this, Priority);
        }
    }
}
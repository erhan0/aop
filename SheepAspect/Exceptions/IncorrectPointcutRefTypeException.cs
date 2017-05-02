using System;
using SheepAspect.Core;

namespace SheepAspect.Exceptions
{
    public class IncorrectPointcutRefTypeException : PointcutDefinitionException
    {
        public IncorrectPointcutRefTypeException(AspectDefinition aspect, IPointcut referrer, string referencedName, Type type): 
            base(aspect, referrer, string.Format("Cannot cast pointcut reference '{0}' as {1}", referencedName, type.Name), null)
        {
        }
    }
}
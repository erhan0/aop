using System;
using System.Diagnostics.Contracts;
using SheepAspect.Core;

namespace SheepAspect.Exceptions
{
    public class PointcutDefinitionException: SheepAspectException
    {
        public PointcutDefinitionException(AspectDefinition aspect, IPointcut pointcut, SheepAspectException innerException)
            : this(aspect, pointcut, FormatMessage(aspect, pointcut, innerException.Message), innerException)
        {
        }

        public PointcutDefinitionException(AspectDefinition aspect, IPointcut pointcut, string message, Exception innerException)
            : base(FormatMessage(aspect, pointcut, message), innerException)
        {
            Contract.Requires(aspect != null);
            Contract.Requires(pointcut != null);

            Aspect = aspect;
            Pointcut = pointcut;
        }

        protected static string FormatMessage(AspectDefinition aspect, IPointcut pointcut, string message)
        {
            return aspect.Name + "::" + pointcut.Name + "\r\n" + message;
        }

        protected AspectDefinition Aspect { get; private set; }
        protected IPointcut Pointcut { get; private set; }

        public override string Source
        {
            get
            {
                return Aspect.Name + "::" + Pointcut.Name;
            }
        }
    }
}
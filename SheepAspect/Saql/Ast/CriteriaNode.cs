using System;
using System.Reflection;
using SheepAspect.Core;
using SheepAspect.Helpers;
using SheepAspect.Saql.Exceptions;

namespace SheepAspect.Saql.Ast
{
    public class CriteriaNode : PointcutNodeBase
    {
        public CriteriaNode(AspectDefinition aspect, string property, IPointcutValueNode value): base(aspect)
        {
            Property = property;
            Value = value;
        }
        public string Property { get; set; }

        public IPointcutValueNode Value { get; set; }

        public object BuildFor(IPointcut pointcut)
        {
            var method = pointcut.GetType().GetMethod("Where" + Property);
            if (method == null)
                throw new UnkonwnCriteriaSaqlException(this, pointcut);

            var parameters = method.GetParameters();

            object[] args;

            if (parameters.Length > 0 && parameters[0].ParameterType == typeof(AspectDefinition))
                 args = new[] { Aspect };
            else
            {
                if (parameters.Length > 0 && Value == null)
                    throw new MissingArgumentSaqlException(this);
                if (parameters.Length == 0 && Value != null)
                    throw new UnexpectedArgumentSaqlException(this);

                if (parameters.Length == 0)
                    args = new object[0];
                else
                {
                    var param = parameters[0];

                    var arg = Construct(param.ParameterType);
                    args = new[] {Value.Build(arg)};
                }
            }

            try
            {
                method.Invoke(pointcut, args);    
            }
            catch(TargetInvocationException e)
            {
                throw e.InnerException;
            }
            
            return pointcut;
        }

        public override string ToString()
        {
            return Value == null ? Property :
                "{0}: {1}".FormatWith(Property, Value);
        }
    }
}
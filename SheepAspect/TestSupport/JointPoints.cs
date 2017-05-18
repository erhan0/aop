using System;
using System.Linq.Expressions;
using SheepAspect.Runtime;
using System.Linq;

namespace SheepAspect.TestSupport
{
    public static class JointPoints
    {
        public static MethodJointPoint Method(Expression<Action> methodExpr)
        {
            var methodCall = methodExpr.Body as MethodCallExpression;
            if (methodCall == null)
            {
                throw new ArgumentException("Not a MethodCallExpression", "methodExpr");
            }

            return (MethodJointPoint)new MethodJointPoint.StaticPart(methodCall.Method, null, null)
                                          .CreateJoinPoint(methodCall.Object, null, methodCall.Arguments.ToArray());
        }
    }
}
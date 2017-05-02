using System.Reflection;

namespace SheepAspect.Runtime
{
    public class CallMethodJointPoint : CallJointPointBase
    {
        public MethodInfo Method { get; private set; }
        
        public object[] Args
        {
            get { return _args; }
        }

        public CallMethodJointPoint(MethodInfo method, AdviceCallback callback, MethodInfo callingMethod, object thisInstance, object target, object[] args)
            : base(method, callback, callingMethod, thisInstance, target, args)
        {
            Method = method;
        }

        public new class StaticPart: JointPointBase.StaticPart
        {
            private readonly MethodInfo _method;
            private readonly MethodInfo _callingMethod;

            public StaticPart(MethodInfo method, AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod)
                : base(advice, callback)
            {
                _method = method;
                _callingMethod = callingMethod;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new CallMethodJointPoint(_method, Callback, _callingMethod, instance, target, args);
            }
        }
    }
}
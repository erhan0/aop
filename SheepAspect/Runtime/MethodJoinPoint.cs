using System.Reflection;

namespace SheepAspect.Runtime
{
    public class MethodJointPoint : MemberJointPointBase
    {
        public MethodInfo Method { get; private set; }
        public object[] Args { get { return args; } }

        public MethodJointPoint(MethodInfo method, object instance, object[] args, AdviceCallback callback) : base(method, callback, instance, args)
        {
            Method = method;
        }

        public new class StaticPart: JointPointBase.StaticPart
        {
            private readonly MethodInfo _method;
            public StaticPart(MethodInfo method, AdviceInvoker advice, AdviceCallback adviceCallback) : base(advice, adviceCallback)
            {
                _method = method;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new MethodJointPoint(_method, instance, args, Callback);
            }
        }
    }
}
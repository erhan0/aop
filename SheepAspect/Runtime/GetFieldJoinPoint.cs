using System.Reflection;

namespace SheepAspect.Runtime
{
    public class GetFieldJointPoint : CallJointPointBase
    {
        public FieldInfo Field { get; private set; }

        public GetFieldJointPoint(FieldInfo field, AdviceCallback callback, MethodInfo callingMethod, object thisInstance, object target, object[] args)
            : base(field, callback, callingMethod, thisInstance, target, args)
        {
            Field = field;
        }

        public new class StaticPart: JointPointBase.StaticPart
        {
            private readonly MethodInfo _callingMethod;
            private readonly FieldInfo _field;

            public StaticPart(FieldInfo field, AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod) : base(advice, callback)
            {
                _callingMethod = callingMethod;
                _field = field;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new GetFieldJointPoint(_field, Callback, _callingMethod, instance, target, args);
            }
        }
    }
}
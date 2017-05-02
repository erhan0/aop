using System.Reflection;

namespace SheepAspect.Runtime
{
    public class SetFieldJointPoint : CallJointPointBase
    {
        public FieldInfo Field { get; private set; }
        
        public object Value
        {
            get { return _args[0]; }
            set { _args[0] = value; }
        }

        public new void Proceed()
        {
            base.Execute();
        }

        public SetFieldJointPoint(FieldInfo field, AdviceCallback callback, MethodInfo callingMethod, object thisInstance, object target, object[] args)
            : base(field, callback, callingMethod, thisInstance, target, args)
        {
            Field = field;
        }

        public new class StaticPart: JointPointBase.StaticPart
        {
            private readonly FieldInfo _field;
            private readonly MethodInfo _callingMethod;

            public StaticPart(FieldInfo field, AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod) : base(advice, callback)
            {
                _callingMethod = callingMethod;
                _field = field;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new SetFieldJointPoint(_field, Callback, _callingMethod, instance, target, args);
            }
        }
    }
}
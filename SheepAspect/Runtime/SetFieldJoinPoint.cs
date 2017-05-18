using System.Reflection;

namespace SheepAspect.Runtime
{
    public class SetFieldJointPoint : CallJointPointBase
    {
        public FieldInfo Field { get; private set; }
        
        public object Value
        {
            get { return args[0]; }
            set { args[0] = value; }
        }

        public void Proceed()
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
            private readonly FieldInfo field;
            private readonly MethodInfo callingMethod;

            public StaticPart(FieldInfo field, AdviceInvoker advice, AdviceCallback callback, MethodInfo callingMethod) : base(advice, callback)
            {
                this.callingMethod = callingMethod;
                this.field = field;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new SetFieldJointPoint(field, Callback, callingMethod, instance, target, args);
            }
        }
    }
}
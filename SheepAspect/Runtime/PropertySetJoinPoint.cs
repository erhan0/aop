using System.Reflection;

namespace SheepAspect.Runtime
{
    public class PropertySetJointPoint: PropertyJointPoint
    {
        public object Value
        {
            get { return _args[0]; }
            set { _args[0] = value; }
        }

        public void Proceed()
        {
            Execute();
        }

        public PropertySetJointPoint(PropertyInfo property, AdviceCallback callback, object instance, object[] args)
            : base(property, callback, instance, args)
        {
        }

        internal new class StaticPart: JointPointBase.StaticPart
        {
            private readonly PropertyInfo _property;

            public StaticPart(PropertyInfo property, AdviceInvoker advice, AdviceCallback callback) : base(advice, callback)
            {
                _property = property;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new PropertySetJointPoint(_property, Callback, instance, args);
            }
        }
    }
}
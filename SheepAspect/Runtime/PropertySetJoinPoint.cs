using System.Reflection;

namespace SheepAspect.Runtime
{
    public class PropertySetJointPoint: PropertyJointPoint
    {
        public object Value
        {
            get { return args[0]; }
            set { args[0] = value; }
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
            private readonly PropertyInfo property;

            public StaticPart(PropertyInfo property, AdviceInvoker advice, AdviceCallback callback) : base(advice, callback)
            {
                this.property = property;
            }

            public override IJointPoint CreateJoinPoint(object instance, object target, object[] args)
            {
                return new PropertySetJointPoint(property, Callback, instance, args);
            }
        }
    }
}
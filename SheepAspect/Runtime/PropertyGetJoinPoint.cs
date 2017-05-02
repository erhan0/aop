using System.Reflection;

namespace SheepAspect.Runtime
{
    public class PropertyGetJointPoint: PropertyJointPoint
    {
        public PropertyGetJointPoint(PropertyInfo property, AdviceCallback callback, object instance, object[] args)
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
                return new PropertyGetJointPoint(_property, Callback, instance, args);
            }
        }
    }
}
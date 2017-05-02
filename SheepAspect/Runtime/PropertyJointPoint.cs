using System.Reflection;

namespace SheepAspect.Runtime
{
    public abstract class PropertyJointPoint : MemberJointPointBase
    {
        protected PropertyJointPoint(PropertyInfo property, AdviceCallback callback, object thisInstance, object[] args)
            : base(property, callback, thisInstance, args)
        {
            Property = property;
        }

        public PropertyInfo Property { get; private set; }
    }
}
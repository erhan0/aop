using System.Reflection;

namespace SheepAspect.Runtime
{
    public interface ICallJointPoint
    {
        MethodInfo CallingMethod { get; }
        MemberInfo TargetMember { get; }
    }

    public abstract class CallJointPointBase : JointPointBase, ICallJointPoint
    {
        private readonly MemberInfo _targetMember;

        protected CallJointPointBase(MemberInfo targetMember, AdviceCallback callback, MethodInfo callingMethod, object thisInstance, object target, object[] args)
            : base(callback, thisInstance, target, args)
        {
            _targetMember = targetMember;
            CallingMethod = callingMethod;
        }

        public MethodInfo CallingMethod { get; private set; }

        MemberInfo ICallJointPoint.TargetMember
        {
            get { return _targetMember; }
        }

        public new object Target
        {
            get { return base.Target; }
            set { base.Target = value; }
        }
    }
}
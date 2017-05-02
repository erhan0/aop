using System.Reflection;

namespace SheepAspect.Runtime
{
    public interface IMemberJointPoint: IJointPoint
    {
        MemberInfo Member { get; }
    }

    public abstract class MemberJointPointBase : JointPointBase, IMemberJointPoint
    {
        private readonly MemberInfo _member;

        protected MemberJointPointBase(MemberInfo member, AdviceCallback callback, object thisInstance, object[] args)
            : base(callback, thisInstance, null, args)
        {
            _member = member;
        }

        MemberInfo IMemberJointPoint.Member
        {
            get { return _member; }
        }
    }
}
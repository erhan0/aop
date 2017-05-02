using System;
using System.Reflection;
using SheepAspect.Core;
using SheepAspect.Helpers;
using SheepAspect.Runtime;
using System.Linq;

namespace SheepAspect.Aspects
{
    public class AttributeAspectFactory: IAspectFactory
    {
        public object CreateInstance(Type type, IJointPoint joinpoint)
        {
            MemberInfo member=null;
            var callJp = joinpoint as ICallJointPoint;
            if (callJp != null)
                member = callJp.TargetMember;

            var memberJp = joinpoint as IMemberJointPoint;
            if (memberJp != null)
                member = memberJp.Member;

            return member == null ? null : member.GetCustomAttributesData()
                .Where(a=> type.IsAssignableFrom(a.Constructor.ReflectedType))
                .Select(ReflectionHelper.CreateAttribute)
                .FirstOrDefault();
        }
    }
}
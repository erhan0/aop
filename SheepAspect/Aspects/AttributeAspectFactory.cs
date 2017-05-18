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
            if (joinpoint is ICallJointPoint callJp)
            {
                member = callJp.TargetMember;
            }

            if (joinpoint is IMemberJointPoint memberJp)
            {
                member = memberJp.Member;
            }

            return member == null ? null : member.GetCustomAttributesData()
                .Where(a=> type.IsAssignableFrom(a.Constructor.ReflectedType))
                .Select(ReflectionHelper.CreateAttribute)
                .FirstOrDefault();
        }
    }
}
using System;
using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace SheepAspect.Aspects
{
    [Aspect]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor)]
    [UseFactory(typeof(AttributeAspectFactory))]
    public abstract class OnMemberBoundaryAttribute: Attribute
    {
        [SelectMethods("HasCustomAttributeType:ThisAspect")]
        [SelectProperties("HasCustomAttributeType:ThisAspect")]
        protected void TargetMembers(){}

        [Around("TargetMembers")]
        public abstract object Around(IMemberJointPoint jp);
    }
}

using System;
using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace SheepAspect.Aspects
{
    [SingletonAspect]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    [UseFactory(typeof(AttributeAspectFactory))]
    public abstract class OnFieldContactAttribute : Attribute
    {
        [SelectFields("HasCustomAttributeType:ThisAspect")]
        protected void TargetFields() { }

        [SelectGetFields("Field:@TargetFields")]
        protected void FieldGets(){}

        [SelectSetFields("Field:@TargetFields")]
        protected void FieldSets(){}

        [Around("FieldGets")]
        public abstract object AroundGet(GetFieldJointPoint jp);

        [Around("FieldSets")]
        public abstract object AroundSet(SetFieldJointPoint jp);
    } 
}
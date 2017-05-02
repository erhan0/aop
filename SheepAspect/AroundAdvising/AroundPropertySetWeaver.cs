using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.AroundAdvising
{
    public class AroundPropertySetWeaver : AroundMethodWeaver
    {
        public AroundPropertySetWeaver(PropertyDefinition targetProperty, AroundAdvice advice, int priority)
            : base(targetProperty.SetMethod, advice, priority)
        {
        }

        protected override void AppendCreateJpStaticPart(ILProcessor il)
        {
            il.Append(OpCodes.Call, Method.Module.ImportMethod<JointPointBase.StaticPart>("ForPropertySet"));
        }

        protected override System.Type GetJoinPointType()
        {
            return typeof(PropertySetJointPoint);
        }
        protected override string GetAdviceTypeName()
        {
            return "Around Property-Setter";
        }
    }
}
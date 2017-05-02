using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers.CecilExtensions;
using SheepAspect.Runtime;

namespace SheepAspect.AroundAdvising
{
    public class AroundPropertyGetWeaver : AroundMethodWeaver
    {
        public AroundPropertyGetWeaver(PropertyDefinition targetProperty, AroundAdvice advice, int priority) : base(targetProperty.GetMethod, advice, priority)
        {
        }

        protected override void AppendCreateJpStaticPart(ILProcessor il)
        {
            il.Append(OpCodes.Call, Method.Module.ImportMethod<JointPointBase.StaticPart>("ForPropertyGet"));
        }

        protected override System.Type GetJoinPointType()
        {
            return typeof (PropertyGetJointPoint);
        }
        protected override string GetAdviceTypeName()
        {
            return "Around Property-Getter";
        }
    }
}
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
            il.Append(OpCodes.Call, method.Module.ImportMethod<JointPointBase.StaticPart>("ForPropertyGet"));
        }

        protected override System.Type JoinPointType
        {
            get
            {
                return typeof(PropertyGetJointPoint);
            }
        }

        protected override string AdviceTypeName
        {
            get
            {
                return "Around Property-Getter";
            }
        }
    }
}
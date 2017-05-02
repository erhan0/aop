using Mono.Cecil;
using Mono.Cecil.Cil;
using SheepAspect.Helpers;

namespace SheepAspect.Exceptions
{
    public class UnsupportedPointcutToAdviseException: SheepAspectException
    {
        public UnsupportedPointcutToAdviseException(MethodDefinition method, Instruction instruction, string adviceName, string adviceType) :
            base("Cannot advice an instruction ({0}, in {1}) with {2}('{3}') advice. Check if it advises a correct type of pointcut.'".FormatWith(instruction.ToString(), method.FullName, adviceName, adviceType))
        {
        }

        public UnsupportedPointcutToAdviseException(MemberReference target, string adviceName, string adviceType) : 
            base("Cannot advice a {0}({1}) with {2}('{3}') advice. Check if it advises a correct type of pointcut.'".FormatWith(target.GetType().Name, target.FullName, adviceName, adviceType))
        {
        }
    }
}
using Mono.Cecil;
using SheepAspect.Helpers;

namespace SheepAspect.Exceptions
{
    public class InvalidAdviceSignatureException: SheepAspectException
    {
        public InvalidAdviceSignatureException(MemberReference method, string adviceType, string message) : 
            base("Incorrect method signature '{0}' for advice type '{1}'. ".FormatWith(method.FullName, adviceType) + message)
        {
        }
    }
}
using Mono.Cecil;

namespace SheepAspect.Exceptions
{
    public class InvalidTypeException: SheepAspectException
    {
        public TypeReference Type { get; private set; }

        public InvalidTypeException(TypeReference type, string message): base(message)
        {
            Type = type;
        }
    }
}
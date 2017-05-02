using Mono.Cecil;

namespace SheepAspect.Exceptions
{
    public class InterfaceAlreadyImplementedException: SheepAspectException
    {
        public InterfaceAlreadyImplementedException(TypeReference classType, TypeReference interfaceType)
            :base(string.Format("Class {0} has already contained implementation of interface {1}", classType, interfaceType))
        {
            
        }
    }
}
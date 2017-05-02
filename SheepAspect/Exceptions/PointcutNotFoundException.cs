using SheepAspect.Helpers;

namespace SheepAspect.Exceptions
{
    public class PointcutNotFoundException: SheepAspectException
    {
        public PointcutNotFoundException(string name, string aspectName): 
            base("Pointcut not found '{0}' in aspect {1}".FormatWith(name, aspectName))
        {
            
        }
    }
}
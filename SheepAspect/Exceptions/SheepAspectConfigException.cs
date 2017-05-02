using System.Xml.Schema;

namespace SheepAspect.Exceptions
{
    public class SheepAspectConfigException: SheepAspectException
    {
        public SheepAspectConfigException(string message, XmlSchemaException exception) : base(message, exception)
        {
        }
    }
}
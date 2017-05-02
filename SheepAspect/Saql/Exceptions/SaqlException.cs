using System;

namespace SheepAspect.Saql.Exceptions
{
    public class SaqlException: ApplicationException
    {
        public SaqlException(string message): base(message)
        {
        }

        public SaqlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
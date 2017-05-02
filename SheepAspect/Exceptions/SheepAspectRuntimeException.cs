using System;

namespace SheepAspect.Exceptions
{
    public class SheepAspectRuntimeException: SheepAspectException
    {
        public SheepAspectRuntimeException(string message)
            : base(message)
        {
        }
    }
}
using System;

namespace SheepAspect.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class AdviseAttribute: Attribute
    {
        
    }
}
using System;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that a class is a SheepAspect aspect class. By default, this attribute is the same as <see cref="SingletonAspectAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class AspectAttribute : Attribute
    {
    }
}
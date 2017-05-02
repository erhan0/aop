using System;
using SheepAspect.Core;

namespace SheepAspect.Framework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class PointcutAttribute: Attribute, IPointcutProvider
    {
        public abstract IPointcut RegisterPointcut(AspectDefinition aspect, string pointcutName);
    }
}
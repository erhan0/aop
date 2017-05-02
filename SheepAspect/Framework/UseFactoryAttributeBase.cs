using System;
using SheepAspect.Core;

namespace SheepAspect.Framework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public abstract class UseFactoryAttributeBase: Attribute
    {
        public abstract IAspectFactory GetFactory();
    }
}
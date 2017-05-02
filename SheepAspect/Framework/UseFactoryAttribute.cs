using System;
using SheepAspect.Core;
using SheepAspect.Runtime;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Specify <see cref="IAspectFactory"/> type for this aspect class.
    /// Aspect class without this attribute will use the value defined in <see cref="AspectRuntime"/>.<see cref="AspectRuntime.Provider"/>.<see cref="IAspectProvider.DefaultFactory"/>.
    /// </summary>
    public class UseFactoryAttribute: UseFactoryAttributeBase
    {
        private readonly Type _factoryType;

        /// <summary>
        /// Initializes a new class of this <see cref="UseFactoryAttribute"/> class.
        /// </summary>
        /// <param name="factoryType">The implementation type of <see cref="IAspectFactory"/>. It must have a public default constructor.</param>
        public UseFactoryAttribute(Type factoryType)
        {
            _factoryType = factoryType;
        }

        public override IAspectFactory GetFactory()
        {
            return (IAspectFactory) Activator.CreateInstance(_factoryType);
        }
    }
}
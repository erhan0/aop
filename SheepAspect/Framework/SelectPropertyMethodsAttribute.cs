using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="PropertyMethodPointcut"/></para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectPropertyMethods("Getter &amp; Name:'Is*' &amp; InType:Namespace:'Foo.Bar.*")]
    /// public void FooGettersPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectPropertyMethodsAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="SelectPropertiesAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL for <see cref="PropertyPointcut"/></param>
        public SelectPropertyMethodsAttribute(string saql)
            : base(saql)
        {
        }   

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<PropertyMethodPointcut>(pointcutName);
        }
    }
}
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="ConstructorPointcut"/> matching type constructors</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectConstructors("InType:Namespace:'Foo.Bar.*" &amp; Args:[Implements:Name:'I*Repository', 'System.String'])]
    /// public void FooConstructorsPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectConstructorsAttribute: SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="SelectConstructorsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL expression for <see cref="ConstructorPointcut"/></param>
        public SelectConstructorsAttribute(string saql) : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<ConstructorPointcut>(pointcutName);
        }
    }
}
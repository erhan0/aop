using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="MethodPointcut"/></para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectMethods("Name:'Execute*' &amp; InType:Namespace:'Foo.Bar.*")]
    /// public void FooMethodsPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectMethodsAttribute: SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="SelectMethodsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL for <see cref="MethodPointcut"/></param>
        public SelectMethodsAttribute(string saql) : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<MethodPointcut>(pointcutName);
        }
    }
}
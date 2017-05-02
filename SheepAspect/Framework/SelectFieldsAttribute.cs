using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="FieldPointcut"/></para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectFields("Name:'_is*' &amp; InType:Namespace:'Foo.Bar.*")]
    /// public void FooFieldsPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectFieldsAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="SelectFieldsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL expression for <see cref="FieldPointcut"/></param>
        public SelectFieldsAttribute(string saql)
            : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<FieldPointcut>(pointcutName);
        }
    }
}
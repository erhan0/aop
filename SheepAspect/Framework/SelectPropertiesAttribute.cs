using System;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="PropertyPointcut"/></para>
    /// <para>To select property's getter and setter methods, see <see cref="SelectPropertyMethodsAttribute"/> instead</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectProperties("Name:'Is*' &amp; InType:Namespace:'Foo.Bar.*")]
    /// public void FooPropertiesPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectPropertiesAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="SelectPropertiesAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL for <see cref="PropertyPointcut"/></param>
        public SelectPropertiesAttribute(string saql)
            : base(saql)
        {
        }   

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return selectAccessorMethods ? aspect.AddPointcut<PropertyMethodPointcut>(pointcutName): aspect.AddPointcut<PropertyPointcut>(pointcutName);
        }

        /// <summary>
        /// Setting SelectAccessorMethods to true will make this attribute to produce a MethodPointcut that select the getters/setters of all properties matched by this PropertyPointcut.
        /// Setting this property to true will also unlock 2 SAQL criteria: "Getter" and "Setter"
        /// <example>
        /// Example:
        /// <code>
        /// [SelectProperties("Name='Getter & Is*'", SelectAccessorMethod=true)]
        /// </code>
        /// Will match the getters of all properties with names beginning with 'Is'
        /// </example>
        /// </summary>
        private bool selectAccessorMethods;
    }
}
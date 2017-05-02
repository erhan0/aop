using System;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="GetFieldPointcut"/> that maches a code instruction of getting the value from a field.</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectGetFields("Field:(Name:'_is*' &amp; InType:Name:'*Service'"))]
    /// public void ServiceFieldGetsPointcut(){}
    /// </code>
    /// (The example will match the line <c>var isActive = emailService._isActive</c> in the code)
    /// </example>
    /// </summary>
    public class SelectGetFieldsAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes new instance of this <see cref="SelectGetFieldsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL expression for <see cref="GetFieldPointcut"/></param>
        public SelectGetFieldsAttribute(string saql)
            : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<GetFieldPointcut>(pointcutName);
        }
    }
}
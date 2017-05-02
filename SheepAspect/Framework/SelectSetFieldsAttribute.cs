using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="SetFieldPointcut"/> that maches a code instruction of setting a field.</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectSetFields("Field:(Name:'_is*' &amp; InType:Name:'*Service'"))]
    /// public void ServiceFieldSetsPointcut(){}
    /// </code>
    /// (The example will match the line <c>emailService._isActive = true</c> in the code)
    /// </example>
    /// </summary>
    public class SelectSetFieldsAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes new instance of this <see cref="SelectSetFieldsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL expression for <see cref="GetFieldPointcut"/></param>
        public SelectSetFieldsAttribute(string saql)
            : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<SetFieldPointcut>(pointcutName);
        }
    }
}
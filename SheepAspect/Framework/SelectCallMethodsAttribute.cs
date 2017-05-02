using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="CallMethodPointcut"/> that maches a code instruction of calling a method.</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectCalMethods("Method: (Name:'Execute*' &amp; Type:Name:'*Service')")]
    /// public void ServiceExecuteCallsPointcut(){}
    /// </code>
    /// (The example will match the line <c>emailService.ExecuteSend("Hello World!");</c> in the code)
    /// </example>
    /// </summary>
    public class SelectCallMethodsAttribute : SaqlPointcutAttribute
    {
        /// <summary>
        /// Initializes new instance of <see cref="SelectCallMethodsAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL expression for <see cref="CallMethodPointcut"/></param>
        public SelectCallMethodsAttribute(string saql)
            : base(saql)
        {
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            return aspect.AddPointcut<CallMethodPointcut>(pointcutName);
        }
    }
}
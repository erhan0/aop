using System;
using System.Collections.Generic;
using System.Reflection;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Surround the execution of methods, properties, method-calls, field gets/sets instructions, etc.</para>
    /// <para>Usage signature:
    /// <code>
    /// [Around("PointcutName")]
    /// public &lt;void | T:object&gt; FooMethod(&lt;T:IJointPoint&gt; jp) { ... }
    /// </code>
    /// </para>
    /// <example>
    /// Example:
    /// <code>
    /// [Around("FooPointcut")]
    /// public int AroundFooPointcut(MethodJointPoint jointPoint)
    /// {
    ///     ....
    ///     jointPoint.Execute();
    ///     ...
    /// }
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AroundAttribute: AdviceProvider
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="AroundAttribute"/> class.
        /// <para>Accepts: <see cref="MethodPointcut"/>, <see cref="PropertyPointcut"/>, <see cref="PropertyMethodPointcut"/>, <see cref="ConstructorPointcut"/>
        /// <see cref="CallMethodPointcut"/>, <see cref="GetFieldPointcut"/>, <see cref="SetFieldPointcut"/>.</para>
        /// </summary>
        /// <param name="pointcutRefs">Names of target pointcuts</param>
        public AroundAttribute(params string[] pointcutRefs)
            : base(pointcutRefs)
        {
            Priority = AroundAdvice.PRIORITY;
        }
        
        protected override IAdvice CreateAdvice(MemberInfo member, IEnumerable<IPointcut> pointcuts)
        {
            return new AroundAdvice(pointcuts, (MethodInfo)member){Priority = Priority};
        }

        /// <summary>
        /// Advices with lower priority values will be applied first.
        /// Default: 100
        /// </summary>
        public int Priority { get; set; }
    }
}
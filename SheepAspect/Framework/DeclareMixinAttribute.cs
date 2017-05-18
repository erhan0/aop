using System;
using System.Collections.Generic;
using System.Reflection;
using SheepAspect.Core;
using SheepAspect.MixinsAdvising;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Add interface implementations to existing types.</para>
    /// <para>Attaching on a factory method:
    /// <code>
    /// [DeclareMixins("TypePointcutName")]
    /// public &lt;T:interface&gt; FooMethod(&lt;optional T:object&gt; instance) 
    /// {
    ///     return new InterfaceImplementation();
    /// }
    /// </code>
    /// </para>
    /// <para>Attaching on a field:
    /// <code>
    /// [DeclareMixins("TypePointcutName")]
    /// public &lt;T:interface&gt; FooField;
    /// </code>
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class DeclareMixinAttribute : AdviceProvider
    {
        /// <summary>
        /// Initializes a new instance of this <see cref="DeclareMixinAttribute"/> class.
        /// <para>Accepts: <see cref="TypePointcut"/>.</para>
        /// </summary>
        /// <param name="pointcutRefs">Names of target <see cref="TypePointcut"/>s.</param>
        public DeclareMixinAttribute(params string[] pointcutRefs)
            : base(pointcutRefs)
        {
        }
        
        /// <summary>
        /// Other interface types to be mixed-in into the target type.
        /// Make sure the implementation returned by this advice also implements this interface.
        /// </summary>
        public Type[] AdditionalInterfaces { get; set; }

        /// <summary>
        /// <para>If set to true, each target instance will only inquire this aspect once to retrieve a mixin implementation.
        /// All subsequent invocations on that instance will be directed to the same mixin implementation reference. 
        /// Set to false to inquire this aspect on every invocation.</para>
        /// <para>Default is <c>true</c> on methods, or <c>false</c> on fields.</para>
        /// </summary>
        public bool? AsFactory { get; set; }

        protected override IAdvice CreateAdvice(MemberInfo member, IEnumerable<IPointcut> pointcuts)
        {
            if (member is MethodInfo method)
            {
                return new DeclareMixinFromMethodAdvice(pointcuts, method, AdditionalInterfaces, AsFactory);
            }

            if (member is FieldInfo field)
            {
                return new DeclareMixinFromFieldAdvice(pointcuts, field, AdditionalInterfaces, AsFactory);
            }

            throw new ArgumentException(string.Format("{0} is not supported", member.GetType()), "member");
            
        }
    }
}
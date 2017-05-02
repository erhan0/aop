using System;
using System.Collections.Generic;
using System.Reflection;
using SheepAspect.Core;
using SheepAspect.DeclareAttributeAdvising;
using SheepAspect.Pointcuts.Impl;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>This advice statically adds attributes to target types, methods, properties, fields, etc.</para>
    /// <example>
    /// Example, to add <c>[Foo(Bar="sheep")]</c> and <c>[Boom("Blah")]</c> attributes into all properties matched by "SomePropertiesPointcut":
    /// <code>
    /// [DeclareAttributes("SomePropertiesPointcut")]
    /// [Foo(Bar="sheep")]
    /// [Boom("Blah")]
    /// public object DummyMeaninglessProperty {get; set;}
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Property|AttributeTargets.Field|AttributeTargets.Class|AttributeTargets.Constructor|AttributeTargets.Event|AttributeTargets.Enum|AttributeTargets.Struct, 
        AllowMultiple = true, Inherited = true)]
    public class DeclareAttributesAttribute: AdviceProvider
    {
        /// <summary>
        /// <para>Initializes a new instance of this <see cref="DeclareAttributesAttribute"/> class.</para>
        /// <para>Accepts: <see cref="TypePointcut"/>, <see cref="MethodPointcut"/>, <see cref="PropertyPointcut"/>, <see cref="PropertyMethodPointcut"/>, <see cref="MethodPointcut"/>, <see cref="FieldPointcut"/>.</para>
        /// </summary>
        /// <param name="pointcutRefs">Names of target pointcuts</param>
        public DeclareAttributesAttribute(params string[] pointcutRefs)
            : base(pointcutRefs)
        {
        }

        protected override IAdvice CreateAdvice(MemberInfo member, IEnumerable<IPointcut> pointcuts)
        {
            return new DeclareAttributesAdvice(pointcuts, member, GetType());
        }
    }
}
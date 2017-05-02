using System;
using SheepAspect.Core;
using SheepAspect.Pointcuts;
using SheepAspect.Pointcuts.Impl;
using SheepAspect.Helpers.CecilExtensions;
using System.Linq;

namespace SheepAspect.Framework
{
    /// <summary>
    /// <para>Produces a <see cref="TypePointcut"/>.</para>
    /// <example>
    /// Example:
    /// <code>
    /// [SelectTypes("Name:'*Service' &amp; Namespace:'Foo.Bar.*")]
    /// public void FooServiceTypesPointcut(){}
    /// </code>
    /// </example>
    /// </summary>
    public class SelectTypesAttribute : SaqlPointcutAttribute
    {
        private readonly Type[] _types;

        /// <summary>
        /// Initializes a new instance of this <see cref="SelectTypesAttribute"/> class.
        /// </summary>
        /// <param name="saql">SAQL for <see cref="TypePointcut"/></param>
        public SelectTypesAttribute(string saql)
            : base(saql)
        {
        }

        /// <summary>
        /// Initializes a new instance of this <see cref="SelectTypesAttribute"/> class.
        /// </summary>
        /// <param name="types">Types to be selected by this <see cref="TypePointcut"/></param>
        public SelectTypesAttribute(params Type[] types)
            : base("")
        {
            _types = types;
        }

        protected override IPointcut CreatePointcut(AspectDefinition aspect, string pointcutName)
        {
            var pointcut = aspect.AddPointcut<TypePointcut>(pointcutName);

            if (_types != null)
            {
                pointcut.WhereAny(_types.Select(t =>
                                  {
                                      var typePointcut = new TypePointcut();
                                      typePointcut.Where(td => td.IsType(t));
                                      return typePointcut;
                                  }).Cast<ITypePointcut>().ToArray());
            }
            return pointcut;
        }
    }
}
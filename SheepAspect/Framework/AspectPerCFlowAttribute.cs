using System;
using System.Collections.Generic;
using System.Linq;
using SheepAspect.AroundAdvising;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.Runtime;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that the instance of an aspect class will live within the span of a particular control flow.
    /// The control flows are defined by the pointcuts passed to the constructor of this attribute.
    /// </summary>
    public class AspectPerCFlowAttribute : AspectAttribute, ILifecycleProvider
    {
        private readonly string[] _pointcutRefs;

        /// <summary>
        /// <para>Initializes a new class of this <see cref="AspectPerCFlowAttribute"/> class.</para>
        /// <para>Accepts: <see cref="MethodPointcut"/>, <see cref="PropertyPointcut"/>, <see cref="PropertyMethodPointcut"/>, <see cref="ConstructorPointcut"/>
        /// <see cref="CallMethodPointcut"/>, <see cref="GetFieldPointcut"/>, <see cref="SetFieldPointcut"/>.</para>
        /// </summary>
        /// <param name="pointcutRefs">
        /// <para>Names of pointcuts that define the control flows that mark the scope of the aspect instance lifetime.</para>
        /// </param>
        public AspectPerCFlowAttribute(params string[] pointcutRefs)
        {
            _pointcutRefs = pointcutRefs;
        }

        public IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory)
        {
            return PerCFlowAspectLifecycle.For(aspectType);
        }

        public void RegisterAdvices(AspectDefinition aspect)
        {
            var perFlowAspect = typeof (PerFlowLifecycleAspect<>).MakeGenericType(aspect.Type);
            aspect.Advise(new AroundAdvice(_pointcutRefs.SelectMany(x=> GetPointcuts(aspect, x)), perFlowAspect.GetMethod("WrapFlowScope")));
            //aspect.Advise(new PerFlowAdvice(_pointcutRefs.SelectMany(aspect.GetPointcuts), aspect.WeavedType));
        }

        private IEnumerable<IPointcut> GetPointcuts(AspectDefinition aspect, string pointcutRef)
        {
            var pointcuts = aspect.GetPointcuts(pointcutRef).ToArray();
            if (!pointcuts.Any())
            {
                throw new PointcutNotFoundException(pointcutRef, aspect.Name);
            }

            return pointcuts;
        }
    }
}
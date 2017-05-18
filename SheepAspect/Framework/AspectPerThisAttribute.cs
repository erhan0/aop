using System;
using System.Collections.Generic;
using System.Linq;
using SheepAspect.Core;
using SheepAspect.Exceptions;
using SheepAspect.LifecycleAdvising;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Framework
{
    /// <summary>
    /// Indicate that the instance of an aspect class will be associated with the <see cref="IJointPoint.This"/> of the jointpoint.
    /// </summary>
    public class AspectPerThisAttribute : AspectAttribute, ILifecycleProvider
    {
        /// <summary>
        /// <para>Optional: name of a pointcut. If specified, the aspect will only be activated (and bound to the This instance) when the selected jointpoints are triggered.</para>
        /// <para>When ommitted, the aspect will be auto-activated on the first instance it's required.</para>
        /// <para>Accepts: <see cref="MethodPointcut"/>, <see cref="PropertyPointcut"/>, <see cref="PropertyMethodPointcut"/>, <see cref="ConstructorPointcut"/>
        /// <see cref="CallMethodPointcut"/>, <see cref="GetFieldPointcut"/>, <see cref="SetFieldPointcut"/>.</para>
        /// </summary>
        public string ActivateOnPointcut { get; set; }

        public IAspectLifecycle GetLifecycle(Type aspectType, IAspectFactory factory)
        {
            return new PerThisAspectLifecycle(aspectType, string.IsNullOrEmpty(ActivateOnPointcut));
        }

        public void RegisterAdvices(AspectDefinition aspect)
        {
            aspect.Advise(new PerThisAdvice(GetPointcuts(aspect).ToArray(), aspect.Type));
        }

        private IEnumerable<IPointcut> GetPointcuts(AspectDefinition aspect)
        {
            if (string.IsNullOrEmpty(ActivateOnPointcut))
            {
                return Enumerable.Empty<IPointcut>();
            }

            var pointcuts = aspect.GetPointcuts(ActivateOnPointcut).ToArray();
            if(!pointcuts.Any())
            {
                throw new PointcutNotFoundException(ActivateOnPointcut, aspect.Name);
            }

            return pointcuts;
        }
    }
}
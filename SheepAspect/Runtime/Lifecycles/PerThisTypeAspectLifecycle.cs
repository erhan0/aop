using System;
using System.Collections.Generic;
using SheepAspect.Core;
using SheepAspect.Helpers;

namespace SheepAspect.Runtime.Lifecycles
{
    public class PerThisTypeAspectLifecycle : IAspectLifecycle
    {
        private readonly Func<IJointPoint, object> _factory;
        private readonly IDictionary<Type, object> _aspectByTypes = new Dictionary<Type, object>(); 

        public PerThisTypeAspectLifecycle(Func<IJointPoint, object> factory)
        {
            _factory = factory;
        }

        public object GetAspect(IJointPoint jointPoint)
        {
            if (jointPoint.This == null)
            {
                return null;
            }

            return _aspectByTypes.GetOrPut(jointPoint.This.GetType(), ()=> _factory(jointPoint));
        }
    }
}
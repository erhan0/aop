using System;
using SheepAspect.Core;

namespace SheepAspect.Runtime.Lifecycles
{
    public class TransientAspectLifecycle : IAspectLifecycle
    {
        private readonly Func<IJointPoint, object> _factory;

        public TransientAspectLifecycle(Func<IJointPoint, object> factory)
        {
            _factory = factory;
        }

        public object GetAspect(IJointPoint jointPoint)
        {
            return _factory(jointPoint);
        }
    }
}
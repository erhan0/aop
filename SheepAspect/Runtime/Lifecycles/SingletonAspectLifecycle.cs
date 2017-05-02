using System;
using SheepAspect.Core;

namespace SheepAspect.Runtime.Lifecycles
{
    public class SingletonAspectLifecycle : IAspectLifecycle
    {
        private readonly Type _type;
        private readonly IAspectFactory _factory;
        
        private object _instance = null;
        private bool _isCreated = false;
        
        public SingletonAspectLifecycle(Type type, IAspectFactory factory)
        {
            _factory = factory;
            _type = type;
        }

        public object GetAspect(IJointPoint jointPoint)
        {
            if(!_isCreated)
            {
                lock(this)
                {
                    if(!_isCreated)
                    {
                        _instance = _factory.CreateInstance(_type, jointPoint);
                        _isCreated = true;
                    }
                }
            }
            return _instance;
        }
    }
}
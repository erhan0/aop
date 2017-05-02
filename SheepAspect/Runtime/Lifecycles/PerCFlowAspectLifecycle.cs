using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using SheepAspect.Core;
using SheepAspect.Helpers;

namespace SheepAspect.Runtime.Lifecycles
{
    public class PerCFlowAspectLifecycle : IAspectLifecycle
    {
        private static readonly IDictionary<Type, PerCFlowAspectLifecycle> Lifecycles = new Dictionary<Type, PerCFlowAspectLifecycle>();
        public static PerCFlowAspectLifecycle For(Type aspectType)
        {
            return Lifecycles.GetOrPut(aspectType, () => new PerCFlowAspectLifecycle());
        }

        private readonly ThreadLocal<Stack> _threadStack = new ThreadLocal<Stack>(() => new Stack());

        private PerCFlowAspectLifecycle()
        {
        }

        public void Push(object instance)
        {
            _threadStack.Value.Push(instance);
        }

        public void Pop()
        {
            _threadStack.Value.Pop();
        }

        public object GetAspect(IJointPoint jointPoint)
        {
            var a = _threadStack.Value.Count == 0 ? null : _threadStack.Value.Peek();
            return a;
        }
    }
}
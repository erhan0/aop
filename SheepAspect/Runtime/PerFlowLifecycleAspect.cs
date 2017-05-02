using SheepAspect.Framework;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Runtime
{
    [SingletonAspect]
    public class PerFlowLifecycleAspect<TAspectType>
    {
        public object WrapFlowScope(IJointPoint joinpoint)
        {
            var aspectType = typeof(TAspectType);
            var lifecycle = PerCFlowAspectLifecycle.For(aspectType);
             
            lifecycle.Push(AspectRuntime.Provider.GetFactory(aspectType).CreateInstance(aspectType, joinpoint));
            try
            {
                return joinpoint.Execute();
            }
            finally
            {
                lifecycle.Pop();
            }
        }
    }
}
using SheepAspect.Framework;
using SheepAspect.Runtime;
using SheepAspect.Runtime.Lifecycles;

namespace SheepAspect.Core
{
    [SingletonAspect]
    public class PerThisLifecycleAspect<TAspect>
    {
         public object Bind(IJointPoint jp)
         {
             PerThisAspectLifecycle.Bind(jp, typeof(TAspect));
             return jp.Execute();
         }
    }
}
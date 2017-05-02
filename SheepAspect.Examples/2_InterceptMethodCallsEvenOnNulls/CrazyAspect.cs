using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace InterceptMethodCallsEvenOnNulls
{
    [SingletonAspect]
    public class CrazyAspect
    {
        [SelectCallMethods(
            @"Method: (InType:Name:'String' & Name:'IndexOf') & 
                FromMethod:InType:Name:'CrazyProgram'")]
        public void CrazyPointcut()
        {
        }

        [Around("CrazyPointcut")]
        public int CrazyAdvise(CallMethodJointPoint jp)
        {
            jp.Target = "crazy"; // We redirect the method call to a different instance
            return (int)jp.Execute();
        }
    }
}
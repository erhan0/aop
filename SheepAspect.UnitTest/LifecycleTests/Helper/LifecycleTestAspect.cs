using SheepAspect.Runtime;

namespace SheepAspect.UnitTest.LifecycleTests.Helper
{
    public class LifecycleTestAspect
    {
        public static int NextUniqueId;
        private readonly int _uniqueId;

        public LifecycleTestAspect()
        {
            _uniqueId = NextUniqueId++;
        }

        public object Around(IJointPoint pointcut)
        {
            return _uniqueId;
        }

        public override string ToString()
        {
            return "Aspect " + _uniqueId;
        }
    }
}
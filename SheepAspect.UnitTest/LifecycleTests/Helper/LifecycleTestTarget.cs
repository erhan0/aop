using System;
using System.Collections.Generic;
using System.Linq;

namespace SheepAspect.UnitTest.LifecycleTests.Helper
{
    public class LifecycleTestTarget
    {
        public object MethodA()
        {
            return "Original";
        }

        public object MethodB()
        {
            return "Original";
        }

        public void Scope(Action action)
        {
            action();
        }

        public object[] Scope2(Func<IEnumerable<object>> action)
        {
            return action().ToArray();
        }

        public void CallScope(Action before, Action scoped, Action after)
        {
            before();
            Scope(scoped);
            after();
        }
    }
}
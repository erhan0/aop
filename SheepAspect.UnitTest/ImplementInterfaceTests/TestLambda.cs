using System;
using SheepAspect.MixinsAdvising;

namespace SheepAspect.UnitTest.ImplementInterfaceTests
{
    public class TestLambda
    {
        private MixinsImplementationBinding<ImplementInterfaceTest, ITestInterface> _binding;

        public void Haha()
        {
            _binding = new MixinsImplementationBinding<ImplementInterfaceTest, ITestInterface>(null, this, new object[0],
                                                                                           Blah);
        }

        private ITestInterface Blah(ImplementInterfaceTest arg)
        {
            return arg == null ? null : arg.MixinTestAdvice();
        }
    }
}
using SheepAspect.MixinsAdvising;

namespace SheepAspect.UnitTest.ImplementInterfaceTests
{
    public class TestLambda
    {
        private MixinsImplementationBinding<ImplementInterfaceTest, ITestInterface> binding;

        public void Haha()
        {
            binding = new MixinsImplementationBinding<ImplementInterfaceTest, ITestInterface>(null, this, new object[0],
                                                                                           Blah);
        }

        private ITestInterface Blah(ImplementInterfaceTest arg)
        {
            return arg?.MixinTestAdvice();
        }
    }
}
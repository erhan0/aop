using System;
using SheepAspect.Framework;
using SheepAspect.Runtime;

namespace WeaveStaticMethodDemo
{
    [SingletonAspect]
    public class DemoAspect
    {
        [SelectMethods("Name:'Calculate*' & InType:Name:'*Helper'")]
        public void CalculateFee()
        {
        }

        [Around("CalculateFee")]
        public int DemoAdvice(MethodJointPoint jp)
        {
            Console.WriteLine("Demo advice for {0} from {1}", jp.Args[0], jp.Method);
            jp.Args[0] = "Sheep!!"; // Subsituting the argument of the method

            return (int)jp.Execute() + 100;
        }
    }
}
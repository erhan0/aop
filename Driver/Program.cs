using SheepAspect.Framework;
using SheepAspect.Runtime;
using System;

namespace Driver
{
    [Aspect]
    public class LoggingAspect
    {
        [SelectMethods("Public & InType: 'Driver.Program'")]
        public void MyPointcut() { }

        [Around("MyPointcut")]
        public object LogQueriesAndUpdates(MethodJointPoint jp)
        {
            Console.WriteLine("Entering method {0} on object {1} with args {2}", jp.Method, jp.This, jp.Args);
            try
            {
                object result = jp.Execute();
                Console.WriteLine("Exits normally with return-value {0}", result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exits with exception: {0}", e);
                throw;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!!");
        }
    }
}

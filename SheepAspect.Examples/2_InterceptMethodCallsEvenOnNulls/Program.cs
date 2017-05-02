using System;

namespace InterceptMethodCallsEvenOnNulls
{
    class Program
    {
        static void Main()
        {
            string str = null;
            
            // Put a breakpoint here. Observe that str==null
            // Then try F11, no null-reference-exception thrown
            Console.WriteLine("Index of z: {0}", str.IndexOf('z'));

            Console.ReadLine();
        }
    }
}

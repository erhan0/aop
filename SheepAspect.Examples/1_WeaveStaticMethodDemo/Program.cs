using System;

namespace WeaveStaticMethodDemo
{
    class Program
    {
        static void Main()
        {
            var result = "Elephant".CalculateAdsFee(10);
            // Put a breakpoint here and keep trying F11
            Console.WriteLine("Index: {0}", result);

            Console.ReadLine();
        }
    }
}

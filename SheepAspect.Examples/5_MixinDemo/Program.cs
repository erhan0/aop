using System;

namespace MixinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var attr in typeof(OrderService).GetProperty("SubmitOrder").GetCustomAttributes(true))
            {
                Console.WriteLine(attr.GetType().FullName);
            }
            /* This also works!
            customer.SaySomething("hohoho");
             * */

            Console.ReadLine();            
        }
    }
}

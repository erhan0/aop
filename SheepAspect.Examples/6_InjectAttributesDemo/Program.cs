using System;
using InjectAttributesDemo.Target;

namespace InjectAttributesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OrderService.SubmitOrder attributes:");
            foreach(var attr in typeof(OrderService).GetMethod("SubmitOrder").GetCustomAttributesData())
                Console.WriteLine(attr);

            Console.ReadLine();
        }
    }
}

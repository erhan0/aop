using System;
using SmartTransactionDemo.App;
using SmartTransactionDemo.DataAccess;

namespace SmartTransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService(new DataStore(), new EmailSender());

            try
            {
                service.SubmitOrder("Coke-Zero", 50);
                Console.WriteLine("");
                Console.WriteLine(""); 
                service.SubmitOrder("Pepsi", 300);
            }
            catch(Exception)
            {
                Console.WriteLine("Demo program (expectedly) completed with exception. Press any key to quit.");
            }
            Console.ReadLine();
        }
    }
}

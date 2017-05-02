using System;
using SmartTransactionDemo.Aspects;

namespace SmartTransactionDemo.App
{
    public class EmailSender
    {
        [NonTransactional]
        public void Send(string message, params object[] args)
        {
            Console.WriteLine("Sending Email:");
            Console.WriteLine("===========================================");
            Console.WriteLine(message, args);
            Console.WriteLine("===========================================");
        }
    }
}
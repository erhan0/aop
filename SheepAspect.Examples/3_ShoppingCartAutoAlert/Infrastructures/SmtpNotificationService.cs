using System;
using ShoppingCartAutoAlert.Domain;

namespace ShoppingCartAutoAlert.Infrastructures
{
    public class SmtpNotificationService: INotificationService
    {
        public void Send(Notice notice, Product prod)
        {
            Console.WriteLine("Sent {0} to [warehouse@kiandra.com]. Item: {1}, stock: {2}\r\n", notice, prod.Name, prod.StockQty);
        }
    }
}
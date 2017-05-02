using System;
using SmartTransactionDemo.Aspects;
using SmartTransactionDemo.DataAccess;

namespace SmartTransactionDemo.App
{
    public class OrderService
    {
        private readonly DataStore _dataStore;
        private readonly EmailSender _emailSender;

        public OrderService(DataStore dataStore, EmailSender emailSender)
        {
            _emailSender = emailSender;
            _dataStore = dataStore;
        }

        [Transaction]
        public int SubmitOrder(string productCode, int qty)
        {
            Console.WriteLine("Submitting order {0} (qty: {1})", productCode, qty);
            var order = new Order(productCode, qty);

            _dataStore.AddOrder(order);
            _emailSender.Send("Thank you for your purchase, your order has been submitted. Order ref: {0} (Product: '{1}', Quantity: {2})\nKwiki Mart", 
                order.Id, order.ProductCode, order.Quantity);
            return order.Id;
        }
    }
}
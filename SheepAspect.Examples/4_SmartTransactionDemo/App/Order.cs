using System;

namespace SmartTransactionDemo.App
{
    public class Order
    {
        private static int _idGen = 1;

        public int Id { get; private set; }
        public string ProductCode { get; private set; }
        public int Quantity { get; private set; }

        public Order(string productCode, int qty)
        {
            ProductCode = productCode;
            Quantity = qty;
            Id = _idGen++;
        }
    }
}
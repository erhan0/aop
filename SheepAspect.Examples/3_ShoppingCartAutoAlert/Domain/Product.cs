using System;

namespace ShoppingCartAutoAlert.Domain
{
    public class Product
    {
        public Product(string name, int stockQty)
        {
            _stockQty = stockQty;
            Name = name;
        }

        public string Name { get; set; }

        private int _stockQty;
        public int StockQty
        {
            get { return _stockQty; }
            set
            {
                Console.WriteLine("Setting stock {0} ", _stockQty);
                _stockQty = value;
                Console.WriteLine("Stock is set. Now: {0} ", _stockQty);
            }
        }
    }
}
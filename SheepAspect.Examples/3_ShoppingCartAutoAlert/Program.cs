using System;
using ShoppingCartAutoAlert.Domain;
using ShoppingCartAutoAlert.Ioc;

namespace ShoppingCartAutoAlert
{
    class Program
    {
        private static ShoppingCart _cart;
        private static Product[] _products;

        static void Main()
        {
            Init();

            while (true)
            {
                PrintProducts();
                var product = PickProduct();
                var qty = EnterQty();

                _cart.AddProduct(product, qty);
            }
        }

        private static void Init()
        {
            IoCConfig.Bootstrap();

            _cart = new ShoppingCart();

            _products = new[]
                            {
                                new Product("Banana", 20), 
                                new Product("Cucumber", 30), 
                                new Product("Beiber CD", 100)
                            };
        }

        private static int EnterQty()
        {
            Console.WriteLine("How many?");
            return int.Parse(Console.ReadLine());
        }

        private static Product PickProduct()
        {
            Console.WriteLine("What you wanna buy?");
            var pId = int.Parse(Console.ReadLine());
            return _products.Length > pId ? _products[pId] : null;
        }

        private static void PrintProducts()
        {
            var i = 0;
            Console.WriteLine("\n====== WELCOME to Kwiki Mart =========");
            foreach (var p in _products)
                Console.WriteLine("{0}/ {1}/ {2}", i++, p.Name, p.StockQty);
        }
    }
}

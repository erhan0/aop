using System;
using System.Collections.Generic;
using SmartTransactionDemo.App;
using System.Linq;

namespace SmartTransactionDemo.DataAccess
{
    public class DataStore
    {
        private static DemoTransactionScope _currentTransaction;

        public static ITransactionScope BeginTransaction()
        {
            return _currentTransaction = new DemoTransactionScope();
        }

        public void AddOrder(Order order)
        {
            _currentTransaction.AddedOrders.Add(order);
        }

        public class DemoTransactionScope : ITransactionScope
        {
            public IList<Order> AddedOrders = new List<Order>();

            private bool _isCommited;

            public DemoTransactionScope()
            {
                Console.WriteLine("Begin transaction");
            }

            public void Dispose()
            {
                if (!_isCommited)
                    Console.WriteLine("Rollback transaction. No order was saved.");
                _currentTransaction = null;
            }

            /// <summary>
            /// Commit the transaction, flush all added orders to the database
            /// For demo purpose, it fails when any Quantity is greater than 100
            /// </summary>
            public void Commit()
            {
                Console.WriteLine("Committing transaction...");
                if (AddedOrders.Any(x => x.Quantity > 100))
                    throw new IndexOutOfRangeException("Quantity is to huge for an order");
                Console.WriteLine("Transaction committed. All orders have been saved.");
                _isCommited = true;
            }
        }
    }

    public interface ITransactionScope : IDisposable
    {
        void Commit();
    }
}
using System.Collections.Generic;

namespace ShoppingCartAutoAlert.Domain
{
    public class ShoppingCart
    {
        private readonly IList<CartItem> _items = new List<CartItem>();

        public void AddProduct(Product product, int qty)
        {
            product.StockQty -= qty;
            _items.Add(new CartItem(product, qty));
        }
    }
}
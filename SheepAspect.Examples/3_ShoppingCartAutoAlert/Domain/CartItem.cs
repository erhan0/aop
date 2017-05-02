namespace ShoppingCartAutoAlert.Domain
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Qty { get; set; }

        public CartItem(Product product, int qty)
        {
            Product = product;
            Qty = qty;
        }
    }
}
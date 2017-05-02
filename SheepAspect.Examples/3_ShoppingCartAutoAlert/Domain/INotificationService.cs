namespace ShoppingCartAutoAlert.Domain
{
    public interface INotificationService
    {
        void Send(Notice notice, Product prod);
    }
}
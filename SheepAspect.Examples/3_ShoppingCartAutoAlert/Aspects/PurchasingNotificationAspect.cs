using SheepAspect.Framework;
using SheepAspect.Runtime;
using ShoppingCartAutoAlert.Domain;

namespace ShoppingCartAutoAlert.Aspects
{
    [SingletonAspect]
    public class PurchasingNotificationAspect
    {
        [SelectProperties("Setter & Name:'StockQty' & InType:Name:'Product'", SelectAccessorMethods = true)]
        public static void SettingProduct()
        {
        }
        
        private readonly INotificationService _notifier;

        public PurchasingNotificationAspect(INotificationService notifier)
        {
            _notifier = notifier;
        }

        [Around("SettingProduct")]
        public void CheckStockForNotification(PropertySetJointPoint jp)
        {
            jp.Proceed();
            if ((int)jp.Value < 5)
            {
                _notifier.Send(Notice.Restock, (Product)jp.This);
            }
        }
    }
}
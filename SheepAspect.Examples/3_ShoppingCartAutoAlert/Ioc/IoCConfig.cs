using SheepAspect.Runtime;
using ShoppingCartAutoAlert.Aspects;
using ShoppingCartAutoAlert.Domain;
using ShoppingCartAutoAlert.Infrastructures;
using StructureMap;

namespace ShoppingCartAutoAlert.Ioc
{
    class IoCConfig
    {
        public static void Bootstrap()
        {
            var container = new Container(reg =>
                                              {
                                                  reg.For<INotificationService>()
                                                      .Use(new SmtpNotificationService()); 
                                                  
                                                  reg.Scan(a =>
                                                               {
                                                                   a.AssemblyContainingType<PurchasingNotificationAspect>();
                                                                   a.SingleImplementationsOfInterface();
                                                                   a.WithDefaultConventions();
                                                               });
                                              });
            AspectRuntime.Provider.DefaultFactory = new StructureMapAspectFactory(container);
        }

    }
}

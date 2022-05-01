using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.MessageQueueModels;
using Models.ProductModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Services.MessageQueueHandlerService;

public interface IMessageQueueHandler
{
    Task ProductUpdatesQueueMessageHandler(ProductionQueueMessage message, CancellationToken cancellationToken);

    Task NewProductProductionQueueMessage(Product message, CancellationToken cancellationToken);
    Task NewTaxProductionQueueMessage(Tax message, CancellationToken cancellationToken);
    Task NewStoreProductionQueueMessage(Store message, CancellationToken cancellationToken);
    Task NewEmploymentRoleProductionQueueMessage(EmploymentRole message, CancellationToken cancellationToken);
    Task NewCustomerProductionQueueMessage(Customer message, CancellationToken cancellationToken);
}


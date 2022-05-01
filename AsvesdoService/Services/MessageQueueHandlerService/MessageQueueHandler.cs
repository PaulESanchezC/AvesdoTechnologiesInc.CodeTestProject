using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.MessageQueueModels;
using Models.ProductModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Services.MessageQueueHandlerService;

public class MessageQueueHandler : IMessageQueueHandler
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MessageQueueHandler> _logger;
    public MessageQueueHandler(IServiceScopeFactory scopeFactory, ILogger<MessageQueueHandler> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }
    public async Task ProductUpdatesQueueMessageHandler(ProductionQueueMessage message, CancellationToken cancellationToken)
    {
        if (message.IsNewProduct)
            await NewProductProductionQueueMessage(message.NewProduct, cancellationToken);
        if (message.IsNewTax)
            await NewTaxProductionQueueMessage(message.NewTax, cancellationToken);
        if (message.IsNewStore)
            await NewStoreProductionQueueMessage(message.NewStore, cancellationToken);
        if (message.IsNewEmploymentRole)
            await NewEmploymentRoleProductionQueueMessage(message.NewEmploymentRole, cancellationToken);
        if (message.IsNewCostumer)
            await NewCustomerProductionQueueMessage(message.NewCustomer, cancellationToken);
    }

    public async Task NewProductProductionQueueMessage(Product message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task NewTaxProductionQueueMessage(Tax message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task NewStoreProductionQueueMessage(Store message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task NewEmploymentRoleProductionQueueMessage(EmploymentRole message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task NewCustomerProductionQueueMessage(Customer message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
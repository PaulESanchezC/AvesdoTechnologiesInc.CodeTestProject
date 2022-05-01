using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.MessageQueueModels;
using Models.ProductModels;
using Models.StoreModels;
using Models.TaxModels;
using StaticData;

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
        _logger.Log(LogLevel.Information, $"**** New Product received from the {RabbitMqConstants.ProductionQueueMessage}");
        using var scope = _scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entity = await _db.Products.AddAsync(message, cancellationToken);
        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem with adding the New Product, operation has failed and stopped.");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem a saving the New Product, operation has failed and stopped.");
            return;
        }
        _logger.Log(LogLevel.Information, "**** The New Product, has been created and is now part of this service Data set.");
    }

    public async Task NewTaxProductionQueueMessage(Tax message, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"**** New Tax received from the {RabbitMqConstants.ProductionQueueMessage}");
        using var scope = _scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entity = await _db.Tax.AddAsync(message, cancellationToken);
        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem with adding the New Tax, operation has failed and stopped.");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem a saving the New Tax, operation has failed and stopped.");
            return;
        }
        _logger.Log(LogLevel.Information, "**** The New Tax, has been created and is now part of this service Data set.");
    }

    public async Task NewStoreProductionQueueMessage(Store message, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"**** New Store received from the {RabbitMqConstants.ProductionQueueMessage}");
        using var scope = _scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entity = await _db.Stores.AddAsync(message, cancellationToken);
        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem with adding the New Store, operation has failed and stopped.");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem a saving the New Store, operation has failed and stopped.");
            return;
        }
        _logger.Log(LogLevel.Information, "**** The New Store, has been created and is now part of this service Data set.");
    }

    public async Task NewEmploymentRoleProductionQueueMessage(EmploymentRole message, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"**** New EmploymentRole received from the {RabbitMqConstants.ProductionQueueMessage}");
        using var scope = _scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entity = await _db.EmploymentRoles.AddAsync(message, cancellationToken);
        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem with adding the New EmploymentRole, operation has failed and stopped.");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem a saving the New EmploymentRole, operation has failed and stopped.");
            return;
        }
        _logger.Log(LogLevel.Information, "**** The New EmploymentRole, has been created and is now part of this service Data set.");
    }

    public async Task NewCustomerProductionQueueMessage(Customer message, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"**** New Customer received from the {RabbitMqConstants.ProductionQueueMessage}");
        using var scope = _scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var entity = await _db.Customers.AddAsync(message, cancellationToken);
        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem with adding the New Customer, operation has failed and stopped.");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, "There seems to be problem a saving the New Customer, operation has failed and stopped.");
            return;
        }
        _logger.Log(LogLevel.Information, "**** The New Customer, has been created and is now part of this service Data set.");
    }
}
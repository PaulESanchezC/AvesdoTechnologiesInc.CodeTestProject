using Models.MessageQueueModels;

namespace Services.MessageQueueHandlerService;

public interface IMessageQueueHandler
{
    Task ProductUpdatesQueueMessageHandler(ProductUpdatesQueueMessage productUpdates, CancellationToken cancellationToken);
}
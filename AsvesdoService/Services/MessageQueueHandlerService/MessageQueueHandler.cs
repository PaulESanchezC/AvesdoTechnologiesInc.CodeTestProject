using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.MessageQueueModels;

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
    public async Task ProductUpdatesQueueMessageHandler(ProductUpdatesQueueMessage productUpdates, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
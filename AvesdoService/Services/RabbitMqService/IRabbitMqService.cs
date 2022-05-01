using Models.MessageQueueModels;

namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void CreateConnection();
    bool ConnectionExists();
    void SendSalesQueueMessage(SalesQueueMessage message);
}
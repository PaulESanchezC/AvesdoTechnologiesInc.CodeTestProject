namespace Services.RabbitMqService;

public interface IRabbitMqService
{
    void SendProductionQueueMessage();
    void SendSalesQueueMessage();
}
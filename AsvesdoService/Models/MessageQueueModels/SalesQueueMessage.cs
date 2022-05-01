using Models.OrderModels;

namespace Models.MessageQueueModels;

public class SalesQueueMessage
{
    public Order? NewOrder { get; set; }
    public Order? OrderUpdated { get; set; }
}
using Models.OrderModels;
using Models.PaymentModels;

namespace Models.MessageQueueModels;

public class SalesQueueMessage
{
    public Order NewOrder { get; set; }
}
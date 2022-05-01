using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderStatusesModels;
using Models.PaymentModels;

namespace Models.OrderModels;

public class OrderDto
{
    #region Public properties

    public string OrderId { get; set; }
    public List<OrderStatusDto> OrderStatuses { get; set; }
    public DateTime OrderDateAndTime { get; set; }
    public CustomerDto Customer { get; set; }
    public List<PaymentDto> Payments { get; set; }
    public double TotalAmount { get; set; }
    public string OrderType { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }

    #endregion
}
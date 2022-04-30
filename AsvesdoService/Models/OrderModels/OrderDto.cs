using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderStatusModels;
using Models.OrderTypeModels;
using Models.PaymentModels;
using Models.StoreModels;

namespace Models.OrderModels;

public class OrderDto
{
    #region Public properties

    public string OrderId { get; set; }

    public OrderStatusDto OrderStatus { get; set; }

    public DateTime OrderDateAndTime { get; set; } = DateTime.Now;

    public CustomerDto Customer { get; set; }

    public List<PaymentDto> Payments { get; set; }

    public OrderTypeDto OrderType { get; set; }

    public List<OrderItemDto> OrderItems { get; set; }

    #endregion
}
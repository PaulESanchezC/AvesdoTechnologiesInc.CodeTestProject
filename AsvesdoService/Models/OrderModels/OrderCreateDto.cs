using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderStatusModels;
using Models.OrderTypeModels;
using Models.PaymentModels;
using Models.StoreModels;

namespace Models.OrderModels;

public class OrderCreateDto
{
    #region Public properties

    public string CustomerId { get; set; }
    public List<PaymentCreateDto> Payments { get; set; }
    public int OrderTypeId { get; set; }
    public List<OrderItemCreateDto> OrderItems { get; set; }

    #endregion
}
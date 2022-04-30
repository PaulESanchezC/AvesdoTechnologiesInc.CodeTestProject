using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderStatusModels;
using Models.OrderTypeModels;
using Models.PaymentModels;
using Models.StoreModels;

namespace Models.OrderModels;

public class OrderUpdateDto
{
    #region Public properties
    [Required]
    public string OrderId { get; set; }
    [Required]
    public int OrderStatusId { get; set; }
    [Required]
    public int OrderTypeId { get; set; }

    #endregion
}
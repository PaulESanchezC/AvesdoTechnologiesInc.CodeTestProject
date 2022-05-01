using System.ComponentModel.DataAnnotations;
using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderStatusesModels;
using Models.PaymentModels;
using Models.StoreModels;

namespace Models.OrderModels;

public class Order
{
    #region Public properties

    [Key]
    public string OrderId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string OrderType { get; set; }

    public List<Payment> Payments { get; set; }

    [Required, Range(0.50, double.MaxValue)]
    public double TotalAmount { get; set; }

    [Required]
    public DateTime OrderDateAndTime { get; set; } = DateTime.Now;

    [Required]
    public string CustomerId { get; set; }

    public Customer Customer { get; set; }

    [Required]
    public List<OrderItem> OrderItems { get; set; }

    [Required(AllowEmptyStrings = false)]
    public List<OrderStatus> OrderStatuses { get; set; }

    #endregion

    #region Internal Properties

    [Required]
    public string StoreId { get; set; }
    public Store Store { get; set; }

    #endregion
}
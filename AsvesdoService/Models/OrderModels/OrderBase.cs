using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderStatusModels;
using Models.OrderTypeModels;
using Models.PaymentModels;
using Models.StoreModels;

namespace Models.OrderModels;

public class OrderBase
{
    #region Public properties

    [Key] public string OrderId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false)]
    public OrderStatus OrderStatus { get; set; }

    [Required]
    public DateTime OrderDateAndTime { get; set; } = DateTime.Now;

    [Required]
    public string CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public CustomerBase Customer { get; set; }

    [Required]
    public string PaymentId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public PaymentBase Payment { get; set; }

    [Required]
    public OrderType OrderType { get; set; }

    #endregion

    #region Internal Properties

    [Required]
    public string StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public StoreBase Store { get; set; }

    #endregion
}
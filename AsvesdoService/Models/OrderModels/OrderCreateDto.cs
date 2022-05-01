using System.ComponentModel.DataAnnotations;
using Models.EnumModels;
using Models.OrderItemModels;
using Models.PaymentModels;


namespace Models.OrderModels;

public class OrderCreateDto
{
    #region Public properties

    [Required]
    public string CustomerId { get; set; }

    [Required]
    public List<PaymentCreateDto> Payments { get; set; }

    [Required]
    public double TotalAmount { get; set; }

    [Required]
    public string OrderType { get; set; }

    [Required]
    public List<OrderItemCreateDto> OrderItems { get; set; }

    [Required]
    public string StoreId { get; set; }

    #endregion
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.OrderModels;
using Models.ProductModels;

namespace Models.OrderItemModels;

public class OrderItemBase
{
    [Required]
    public string OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public OrderBase Order { get; set; }

    [Required]
    public ProductBase Product { get; set; }

    [Required]
    public int Quantity { get; set; }
}
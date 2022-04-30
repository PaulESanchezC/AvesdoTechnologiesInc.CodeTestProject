using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.ProductModels;

namespace Models.OrderItemModels;

public class OrderItemBase
{
    #region Public Properties

    [Key]
    public string OrderId { get; set; }

    [Required]
    public string ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductBase Product { get; set; }

    [Required]
    public int Quantity { get; set; }

    #endregion

}
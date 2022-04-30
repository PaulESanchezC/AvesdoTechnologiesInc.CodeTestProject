using System.ComponentModel.DataAnnotations;

namespace Models.OrderItemModels;

public class OrderItemCreateDto
{
    #region Public Properties

    [Required]
    public string OrderId { get; set; }
    [Required]
    public string ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }

    #endregion
}
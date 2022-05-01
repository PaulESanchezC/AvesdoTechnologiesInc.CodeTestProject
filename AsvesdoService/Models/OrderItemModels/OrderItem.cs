using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.ProductModels;


namespace Models.OrderItemModels;

public class OrderItem
{
    #region Public Properties

    [Key]
    public string OrderItemId { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public int Quantity { get; set; }

    #endregion

}
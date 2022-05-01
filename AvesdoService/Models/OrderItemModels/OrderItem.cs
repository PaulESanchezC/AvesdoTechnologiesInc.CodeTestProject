using System.ComponentModel.DataAnnotations;
using Models.OrderModels;
using Models.ProductModels;
using Newtonsoft.Json;


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
    public string OrderId { get; set; }

    [JsonIgnore]
    public Order Order { get; set; }

    [Required]
    public int Quantity { get; set; }

    #endregion

}
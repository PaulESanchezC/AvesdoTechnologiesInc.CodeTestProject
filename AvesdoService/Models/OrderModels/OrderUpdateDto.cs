using System.ComponentModel.DataAnnotations;

namespace Models.OrderModels;

public class OrderUpdateDto
{
    #region Public properties
    [Required]
    public string OrderId { get; set; }
    [Required]
    public string OrderType { get; set; }

    #endregion
}
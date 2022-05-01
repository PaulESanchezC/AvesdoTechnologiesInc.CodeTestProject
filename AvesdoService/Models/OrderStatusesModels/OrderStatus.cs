using System.ComponentModel.DataAnnotations;
using Models.OrderModels;
using Newtonsoft.Json;

namespace Models.OrderStatusesModels;


public class OrderStatus
{
    #region Public Properties

    [Key]
    public string OrderStatusId { get; set; } = Guid.NewGuid().TinyGuid();

    [Required(AllowEmptyStrings = false),MaxLength(100)]
    public string Status { get; set; }

    [JsonIgnore]
    public List<Order> Orders { get; set; }

    public DateTime StatusDate { get; set; } = DateTime.Now;

    #endregion
}
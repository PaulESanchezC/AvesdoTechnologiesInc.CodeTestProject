using System.ComponentModel.DataAnnotations;
using Models.CustomerModels;
using Models.OrderModels;
using Models.StoreModels;
using Newtonsoft.Json;

namespace Models.PaymentModels;

public class Payment
{
    #region Public Properties

    [Key]
    public string PaymentId { get; set; } = Guid.NewGuid().ToString();

    [Required, Range(0.50, double.MaxValue)]
    public double SubTotal { get; set; }

    [Required, Range(0.00, double.MaxValue)]
    public double TaxesAmount { get; set; }

    [Required, Range(0.50, double.MaxValue)]
    public double TotalAmount { get; set; }

    [Required(AllowEmptyStrings = false),MaxLength(100)]
    public string PaymentMethod { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Required]
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required]
    public string StoreId { get; set; }
    public Store Store { get; set; }

    [Required]
    public string OrderId { get; set; }
    [JsonIgnore]
    public Order Order { get; set; }

    #endregion

    #region Internal Properties

    //TODO: Sadly, I could not come up with data that is not already in public properties...

    #endregion
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Models.PaymentModels;

public class PaymentBase
{
    #region Public Properties

    [Key]
    public string PaymentId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false),MaxLength(100)]
    public string PaymentMethod { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Required]
    public string CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public CustomerBase Customer { get; set; }

    [Required]
    public string OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public OrderBase Order { get; set; }

    [Required, Range(0.50,double.MaxValue)]
    public double TotalAmount { get; set; }

    [Required]
    public List<TaxBase> Taxes { get; set; }


    [Required]
    public string StoreId { get; set; }
    [ForeignKey(nameof(StoreId))]
    public StoreBase Store { get; set; }

    #endregion

    #region Internal Properties

    //TODO: Sadly, I could not come up with data that is not already in public properties...

    #endregion
}
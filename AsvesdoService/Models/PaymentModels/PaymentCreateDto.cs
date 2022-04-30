using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.CustomerModels;
using Models.OrderModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Models.PaymentModels;

public class PaymentCreateDto
{
    #region Public Properties

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string PaymentMethod { get; set; }

    [Required]
    public string CustomerId { get; set; }

    [Required]
    public string OrderId { get; set; }

    [Required, Range(0.50, double.MaxValue)]
    public double TotalAmount { get; set; }

    [Required]
    public List<int> TaxesId { get; set; }

    [Required]
    public string StoreId { get; set; }

    #endregion
}
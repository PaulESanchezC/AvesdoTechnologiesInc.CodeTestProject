using System.ComponentModel.DataAnnotations;
using Models.EnumModels;

namespace Models.PaymentModels;

public class PaymentCreateDto
{
    #region Public Properties

    [Required, Range(0.50, double.MaxValue)]
    public double SubTotal { get; set; }

    [Required, Range(0.00, double.MaxValue)]
    public double TaxesAmount { get; set; }

    [Required, Range(0.50, double.MaxValue)]
    public double TotalAmount { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string PaymentMethod { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string CustomerId { get; set; }

    [Required]
    public string StoreId { get; set; }

    #endregion
}
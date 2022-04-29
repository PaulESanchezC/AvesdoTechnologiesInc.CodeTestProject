using System.ComponentModel.DataAnnotations;
using Models.CustomerModels;
using Models.OrderModels;
using Models.TaxModels;

namespace Models.PaymentModels;

public class PaymentBase
{
    #region Public Properties

    [Key]
    public string PaymentId { get; set; } = Guid.NewGuid().ToString();

    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public CustomerBase Customer { get; set; }
    public OrderBase Order { get; set; }
    public double TotalAmount { get; set; }
    public List<TaxBase> Taxes { get; set; }

    #endregion
}
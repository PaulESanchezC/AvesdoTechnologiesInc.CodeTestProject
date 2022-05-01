using Models.CustomerModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Models.PaymentModels;

public class PaymentDto
{
    #region Public Properties

    public string PaymentId { get; set; }
    public double SubTotal { get; set; }
    public double TaxesAmount { get; set; }
    public double TotalAmount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public StoreDto Store { get; set; }

    #endregion
}
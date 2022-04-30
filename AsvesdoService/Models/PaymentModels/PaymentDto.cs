using Models.CustomerModels;
using Models.OrderModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Models.PaymentModels;

public class PaymentDto
{
    #region Public Properties

    public string PaymentId { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public string CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public string OrderId { get; set; }
    public OrderDto Order { get; set; }
    public double TotalAmount { get; set; }
    public List<TaxDto> Taxes { get; set; }
    public string StoreId { get; set; }
    public StoreDto Store { get; set; }

    #endregion
}
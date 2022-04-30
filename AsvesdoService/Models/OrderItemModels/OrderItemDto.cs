using Models.ProductModels;

namespace Models.OrderItemModels;

public class OrderItemDto
{
    #region Public Properties

    public string OrderId { get; set; }
    public string ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int Quantity { get; set; }

    #endregion
}
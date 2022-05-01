namespace Models.OrderStatusesModels;


public class OrderStatusDto
{
    #region Public Properties

    public string OrderStatusId { get; set; } = Guid.NewGuid().TinyGuid();
    public string Status { get; set; }
    public DateTime StatusDate { get; set; }

    #endregion
}
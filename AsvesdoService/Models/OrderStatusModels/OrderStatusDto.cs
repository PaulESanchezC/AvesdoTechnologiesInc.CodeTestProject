using System.ComponentModel.DataAnnotations;

namespace Models.OrderStatusModels;

public class OrderStatusDto
{
    #region Public Properties

    public int OrderStatusId { get; set; }
    public string StatusDescription { get; set; }

    #endregion
}
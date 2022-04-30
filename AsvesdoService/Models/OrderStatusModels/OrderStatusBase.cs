using System.ComponentModel.DataAnnotations;

namespace Models.OrderStatusModels;

public class OrderStatusBase
{
    #region Public Properties

    [Key]
    public int OrderStatusId { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StatusDescription { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsDeprecated { get; set; } = false;
    public bool IsActive { get; set; } = true;

    #endregion

}
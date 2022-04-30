using System.ComponentModel.DataAnnotations;

namespace Models.OrderTypeModels;

public class OrderTypeBase
{
    #region Public Properties

    [Key]
    public int OrderTypeId { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string OrderTypeDefinition { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsDeprecated { get; set; } = false;
    public bool IsActive { get; set; } = true;

    #endregion
}
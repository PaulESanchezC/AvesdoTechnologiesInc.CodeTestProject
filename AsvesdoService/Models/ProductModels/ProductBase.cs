using System.ComponentModel.DataAnnotations;

namespace Models.ProductModels;

public class ProductBase
{
    #region Public properties

    [Key]
    public string ProductId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string ProductName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(240)]
    public string Description { get; set; }

    [Required,Range(0.50,Double.MaxValue)]
    public double Price { get; set; }

    #endregion

    #region Internal Properties
    public bool IsActive { get; set; } = false;
    public DateTime DateCreated { get; set; } = DateTime.Now;

    #endregion
}
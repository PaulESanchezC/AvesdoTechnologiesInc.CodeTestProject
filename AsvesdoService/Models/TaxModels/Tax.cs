using System.ComponentModel.DataAnnotations;
using Models.StoreModels;

namespace Models.TaxModels;

public class Tax
{
    #region Public properties

    [Key]
    public int TaxId { get; set; }

    [Required,Range(0,100)]
    public double TaxPercentage { get; set; }

    [Required,MaxLength(20)]
    public string TaxPercentageString { get; set; }

    [Required, MaxLength(100)]
    public string TaxDescription { get; set; }

    [Required, MaxLength(20)]
    public string TaxAcronym { get; set; }

    [Required, MaxLength(20)]
    public string StateOrProvinceAcronym { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StateOrProvinceName { get; set; }

    #endregion

    #region Internal Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    [Required]
    public List<Store> Stores { get; set; }

    #endregion
}
using System.ComponentModel.DataAnnotations;

namespace Models.TaxModels;

public class TaxBase
{
    #region Public properties

    [Key] public string TaxId { get; set; }
    public double TaxPercentage { get; set; }
    public string TaxDescription { get; set; }
    public string TaxAcronym { get; set; }

    #endregion

    #region Internal Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }
    #endregion
}
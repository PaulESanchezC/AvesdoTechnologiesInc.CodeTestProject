namespace Models.TaxModels;

public class TaxDto
{
    #region Public properties
    public int TaxId { get; set; }
    public double TaxPercentage { get; set; }
    public string TaxPercentageString { get; set; }
    public string TaxDescription { get; set; }
    public string TaxAcronym { get; set; }

    #endregion
}
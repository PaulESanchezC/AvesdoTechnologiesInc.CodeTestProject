using Models.TaxModels;

namespace Models.StoreModels;

public class StoreDto
{
    #region Public Properties

    public string StoreId { get; set; }
    public string StoreName { get; set; }
    public string StorePhoneNumber { get; set; }
    public string StoreEmail { get; set; }
    public string StoreWebsite { get; set; }
    public string StoreAddress { get; set; }
    public string StoreCity { get; set; }
    public string StoreStateOrProvince { get; set; }
    public string StoreZipCode { get; set; }
    public List<TaxDto> Tax { get; set; }

    #endregion
}
using Models.PreferredPronounsModels;

namespace Models.CustomerModels;

public class CustomerDto
{
    #region Public Properties

    public string CustomerId { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerStateOrProvince { get; set; }
    public string CustomerZipCode { get; set; }
    public PreferredPronounDto CustomerPreferredPronoun { get; set; }

    #endregion
}
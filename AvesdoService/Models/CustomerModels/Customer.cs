using System.ComponentModel.DataAnnotations;

namespace Models.CustomerModels;

public class Customer
{
    #region Public Properties

    [Key]
    public string CustomerId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string CustomerFirstName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string CustomerLastName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string CustomerPhoneNumber { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100), EmailAddress]
    public string CustomerEmail { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(300)]
    public string CustomerAddress { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string CustomerCity { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string CustomerStateOrProvince { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(20)]
    public string CustomerZipCode { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(20)]
    public string CustomerPreferredPronoun { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    #endregion
}
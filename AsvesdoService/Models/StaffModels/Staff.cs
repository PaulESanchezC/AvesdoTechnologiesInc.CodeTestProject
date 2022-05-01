using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.EmploymentRoleModels;
using Models.StoreModels;

namespace Models.StaffModels;

public class Staff
{
    #region Public Properties

    [Key]
    public string StaffId { get; set; } = Guid.NewGuid().TinyGuid();

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string StaffFirstName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string StaffLastName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string StaffPhoneNumber { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100), EmailAddress]
    public string StaffEmail { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(300)]
    public string StaffAddress { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StaffCity { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StaffStateOrProvince { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(20)]
    public string StaffZipCode { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(20)]
    public string StaffPreferredPronoun { get; set; }

    [Required]
    public string StoreId { get; set; }
    public Store Store { get; set; }

    [Required]
    public int EmploymentRoleId { get; set; }
    public EmploymentRole EmploymentRole { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    #endregion
}
using System.ComponentModel.DataAnnotations;
using Models.EmploymentRoleModels;
using Models.StoreModels;

namespace Models.StaffModels;

public class StaffUpdateDto

{
    #region Public Properties
    [Required]
    public string StaffId { get; set; }
    [Required]
    public string StaffFirstName { get; set; }
    [Required]
    public string StaffLastName { get; set; }
    [Required]
    public string StaffPhoneNumber { get; set; }
    [Required]
    public string StaffEmail { get; set; }
    [Required]
    public string StaffAddress { get; set; }
    [Required]
    public string StaffCity { get; set; }
    [Required]
    public string StaffStateOrProvince { get; set; }
    [Required]
    public string StaffZipCode { get; set; }
    [Required]
    public string StoreId { get; set; }
    [Required]
    public int EmploymentRoleId { get; set; }

    #endregion
}
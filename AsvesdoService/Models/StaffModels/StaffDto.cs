using Models.EmploymentRoleModels;
using Models.StoreModels;

namespace Models.StaffModels;

public class StaffDto

{
    #region Public Properties

    public string StaffId { get; set; }
    public string StaffFirstName { get; set; }
    public string StaffLastName { get; set; }
    public string StaffPhoneNumber { get; set; }
    public string StaffEmail { get; set; }
    public string StaffAddress { get; set; }
    public string StaffCity { get; set; }
    public string StaffStateOrProvince { get; set; }
    public string StaffZipCode { get; set; }
    public StoreDto Store { get; set; }
    public EmploymentRoleDto EmploymentRole { get; set; }

    #endregion
}
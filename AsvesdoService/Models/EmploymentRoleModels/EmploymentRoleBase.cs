using System.ComponentModel.DataAnnotations;

namespace Models.EmploymentRoleModels;

public class EmploymentRoleBase
{
    #region Public Properties

    [Key]
    public string EmploymentRoleId { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string EmploymentRoleName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string EmploymentRoleDescription { get; set; }

    #endregion

    #region Internal Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    #endregion
}
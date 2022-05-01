using System.ComponentModel.DataAnnotations;

namespace Models.EmploymentRoleModels;

public class EmploymentRoleDto
{
    #region Public Properties

    public int EmploymentRoleId { get; set; }
    public string EmploymentRoleName { get; set; }
    public string EmploymentRoleDescription { get; set; }

    #endregion
}
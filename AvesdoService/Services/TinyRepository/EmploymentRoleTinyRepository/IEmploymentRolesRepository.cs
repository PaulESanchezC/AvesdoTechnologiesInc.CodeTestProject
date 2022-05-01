using Models.EmploymentRoleModels;

namespace Services.TinyRepository.EmploymentRoleTinyRepository;

public interface IEmploymentRolesRepository : ITinyRepository<EmploymentRole, EmploymentRoleDto>
{ }
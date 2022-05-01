using AutoMapper;
using Data;
using Models.EmploymentRoleModels;

namespace Services.TinyRepository.EmploymentRoleTinyRepository;

public class EmploymentRolesRepository : TinyRepository<EmploymentRole,EmploymentRoleDto> , IEmploymentRolesRepository
{
    public EmploymentRolesRepository(IMapper mapper, ApplicationDbContext db) : base(mapper, db)
    {
    }
}
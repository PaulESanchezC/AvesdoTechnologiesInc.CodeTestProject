using Models.ResponseModels;
using Models.StaffModels;

namespace Services.Repository.StaffRepository;

public interface IStaffRepository : IRepository<Staff, StaffDto, StaffCreateDto, StaffUpdateDto>
{
}

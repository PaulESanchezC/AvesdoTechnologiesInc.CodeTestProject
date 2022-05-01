using AutoMapper;
using Data;
using Models.StaffModels;

namespace Services.Repository.StaffRepository;

public class StaffRepository : Repository<Staff,StaffDto,StaffCreateDto,StaffUpdateDto> , IStaffRepository
{ 
    public StaffRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    { }
}
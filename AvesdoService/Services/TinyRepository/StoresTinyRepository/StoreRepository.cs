using AutoMapper;
using Data;
using Models.StaffModels;
using Models.StoreModels;

namespace Services.TinyRepository.StoresTinyRepository;

public class StoreRepository : TinyRepository<Store,StoreDto>, IStoreRepository
{
    public StoreRepository(IMapper mapper, ApplicationDbContext db) : base(mapper, db)
    { }
}
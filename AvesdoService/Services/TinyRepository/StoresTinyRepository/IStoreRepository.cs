using Models.StoreModels;

namespace Services.TinyRepository.StoresTinyRepository;

public interface IStoreRepository : ITinyRepository<Store,StoreDto>
{ }
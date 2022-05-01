using Models.TaxModels;

namespace Services.TinyRepository.TaxTinyRepository;

public interface ITaxRepository : ITinyRepository<Tax,TaxDto>
{
}
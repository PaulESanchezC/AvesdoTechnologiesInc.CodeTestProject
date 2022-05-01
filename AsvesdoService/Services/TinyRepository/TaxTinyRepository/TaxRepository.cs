using AutoMapper;
using Data;
using Models.TaxModels;

namespace Services.TinyRepository.TaxTinyRepository;

public class TaxRepository : TinyRepository<Tax,TaxDto> , ITaxRepository
{
    public TaxRepository(IMapper mapper, ApplicationDbContext db) : base(mapper, db)
    { }
}
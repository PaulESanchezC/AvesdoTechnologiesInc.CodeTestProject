using AutoMapper;
using Data;
using Models.ProductModels;

namespace Services.TinyRepository.ProductsTinyRepository;

public class ProductRepository : TinyRepository<Product,ProductDto> , IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public ProductRepository(IMapper mapper, ApplicationDbContext db) : base(mapper, db)
    {
        _mapper = mapper;
        _db = db;
    }
}
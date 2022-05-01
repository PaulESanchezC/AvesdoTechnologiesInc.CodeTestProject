using Models.ProductModels;

namespace Services.TinyRepository.ProductsTinyRepository;

public interface IProductRepository : ITinyRepository<Product, ProductDto>
{
}
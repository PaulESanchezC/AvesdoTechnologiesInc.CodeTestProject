using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.TinyRepository.ProductsTinyRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAllFranchiseProducts")]
        public async Task<IActionResult> GetAllFranchiseProducts(CancellationToken cancellationToken)
        {
            var request = await _productRepository.GetAllByAsync(null, orderBy => orderBy.Price, true, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }


        [HttpGet("GetSingleProductById/{productId}")]
        public async Task<IActionResult> GetSingleProductById(string productId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(productId))
            {
                ModelState.AddModelError("productId","The productId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _productRepository.GetSingleByAsync(product => product.ProductId == productId,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}

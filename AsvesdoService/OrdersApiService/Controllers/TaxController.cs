using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.TinyRepository.TaxTinyRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxRepository _tax;
        public TaxController(ITaxRepository tax)
        {
            _tax = tax;
        }

        [HttpGet("GetAllTaxBrackets")]
        public async Task<IActionResult> GetAllTaxBrackets(CancellationToken cancellationToken)
        {
            var request = await _tax.GetAllByAsync(null, orderby => orderby.TaxPercentage, true, 
                cancellationToken, include => include.Stores);
            return StatusCode(request.StatusCode,request);
        }

        [HttpGet("GetSingleTaxBracketByTaxId/{taxId:int}")]
        public async Task<IActionResult> GetSingleTaxBracketByTaxId(int taxId, CancellationToken cancellationToken)
        {
            if (taxId <= 0)
            {
                ModelState.AddModelError("taxId", "The taxId field is required.");
                return BadRequest(ModelState);
            }
            var request = await _tax.GetSingleByAsync(tax => tax.TaxId == taxId, cancellationToken, include => include.Stores);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetTaxBracketForStateOrProvince/{nameOrAcronym}")]
        public async Task<IActionResult> GetTaxBracketForStateOrProvince(string nameOrAcronym, CancellationToken cancellationToken)
                {
            if (string.IsNullOrEmpty(nameOrAcronym))
            {
                ModelState.AddModelError("nameOrAcronym", "The nameOrAcronym field is required.");
                return BadRequest(ModelState);
            }

            var request = await _tax.GetAllByAsync(tax => tax.StateOrProvinceAcronym == nameOrAcronym.ToUpper().Trim()
                                                             || tax.StateOrProvinceName.ToLower() == nameOrAcronym.ToLower().Trim(),
                null,false, cancellationToken, includes => includes.Stores);
            return StatusCode(request.StatusCode, request);
        }

    }
}

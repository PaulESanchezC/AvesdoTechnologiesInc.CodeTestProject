using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repository.OrderRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTutorialController : ControllerBase
    {
        #region Dependencies, Constructor
        public ApiTutorialController()
        { }
        #endregion


        [HttpGet("GetTheTutorialInformationGuide")]
        public async Task<IActionResult> GetTheTutorialInformationGuide()
        {
            //TODO: Implement GetTheTutorialInformationGuide()
            return Ok("To be implemented");
        }


        [HttpGet("GetRandomJoke")]
        public async Task<IActionResult> GetRandomJoke()
        {
            return Ok("knock knock, who's there: Theresa, Theresa who. Theresa fly to my plate");
        }
    }
}

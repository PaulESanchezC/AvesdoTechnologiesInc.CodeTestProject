using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.TutorialModels;
using Services.Repository.OrderRepository;
using Services.TutorialServices;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTutorialController : ControllerBase
    {
        private readonly ITutorialService _tutorial;
        public ApiTutorialController(ITutorialService tutorial)
        {
            _tutorial = tutorial;
        }

        [HttpGet("GetTheTutorialInformationGuide")]
        public async Task<IActionResult> GetTheTutorialInformationGuide()
        {
            return Ok(@"
                Hi, welcome to this tutorial.
        These Tutorial Endpoints will provide you with most data required to allow you ease of use of this services.

        First: this Restful Api does not have an authentication service handler, therefore i am willingly providing a forever valid JWT token
            (it will only be required for verbs: Post, Put and Delete)
        
        How to Create Orders:
            well, i give you 2 options, 
                option 1 => I made an endpoint that can assist you in creating the Request Body for the Create Order Endpoint, it basically constructs a
                 OrderCreateDto object for you, 
                option 2 => you can simply edit the Json object in the body request scheme that the swaggerUi gives out of the box.
        
        RabbitMq:
            I decided to add entities that do not have a Post, Put or Delete request handlers, that is where RabbitMq slides in, my assumption is,
            
                    This rest api service is one of many micro services distributed for a franchise (in this case, a pizzeria restaurant) 
                    Therefore, entities like, Products, Tax, EmploymentRoles are handled through a message queue.
            
            I have made a Basic message consumer for the Products entity, where i pretend to be consuming from a queue that fires a Post/Put/Delete:PuttProductEvent.

        Thank you for your time.
");
        }


        [HttpPost("OrderCreateDto:Helper/")]
        public async Task<IActionResult> OrderCreateDtoHelper([FromBody] OrderCreateDtoHelper orderCreateDtoHelper, CancellationToken cancellationToken)
        {
            var request = await _tutorial.GenerateOrderCreateDtoAsync(orderCreateDtoHelper.storeId,
                orderCreateDtoHelper.customerId, cancellationToken, orderCreateDtoHelper.TutorialOrderCreateDto.ToArray());
            return Ok(request);
        }

        [HttpGet("JwtTokenProvider")]
        public async Task<IActionResult> JwtTokenProvider()
        {
            var token = await _tutorial.ProvideJwtToken();
            return Ok(token);
        }

        [HttpGet("GetTheJoke")]
        public async Task<IActionResult> GetRandomJoke()
        {
            return Ok("knock knock, who's there: Theresa, Theresa who. Theresa fly to my plate");
        }
    }
}

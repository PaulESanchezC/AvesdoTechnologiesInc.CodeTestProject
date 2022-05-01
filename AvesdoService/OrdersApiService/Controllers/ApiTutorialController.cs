using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.TutorialModels;
using Services.TutorialServices;

namespace ApiOrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiTutorialController : ControllerBase
{
    private readonly ITutorialService _tutorial;
    public ApiTutorialController(ITutorialService tutorial)
    {
        _tutorial=tutorial;
    }

    [HttpGet("GetTheTutorialInformationGuide")]
    public IActionResult GetTheTutorialInformationGuide()
    {
        return Ok(@"
        Hi, welcome to this tutorial.
        These Tutorial Endpoints will provide you with most data required to allow you ease of use of this services.

        'First': this Restful Api does not have an authentication service manager/handler, but every endpoint of the Verb Post,Put and Delete will require one.
            Do not worry, the next Endpoint is going to give you one, this JwtToken is just checking for the SigningKey, which i provided in the AppSettings.json,
             which brings me to my second point...
        
        'Second': I did not user User Secrets, that way if you do a decided to run this, on your local host or virtual machines, it should work, with the exception of 
            RabbitMq, which of course the erlang cookie is required. so yeah.      
        
        'How to Create Orders':
            well, i give you 2 options, 
                'option 1' =>  The QuickOrder endpoint will always generate the same order: 
                                1 All dressed pizza, 1 355ml can, For: Marty Byrde, on the Bc store.
               ' option 2' => I made an endpoint that can assist you in creating the Request Body for the Create Order Endpoint, it basically constructs a
                 OrderCreateDto object for you,     
               ' option 3' => you can simply edit the Json object in the body request scheme that the swaggerUi gives out of the box.
        
        The Endpoint 'OrderCreateDto:Helper' is probably the best way to make Orders, you will need the JwtToken for that too.
        So go to the Products Endpoints and find your thing, jot them down and get the Body built for ya at least.

        RabbitMq:
            I decided to add entities that do not have a Post, Put or Delete request handlers, that is where RabbitMq slides in, my assumption is,
            
                    This rest api service is one of many micro services distributed for a franchise (in this case, a pizzeria restaurant) 
                    Therefore, entities like, Products, Tax, EmploymentRoles are handled through a message queue.
            
            I have made a Basic message consumer for the Products entity, where i pretend to be consuming from a queue that fires a Post/Put/Delete:PuttProductEvent.

        For mode information about the code, libraries, conventions, and practices use the GET:'CodeInformation' endpoint.
        
        Thank you for your time.
        Developed by Paul E. Sanchez C.
        ");
    }

    [HttpGet("JwtTokenProvider")]
    public async Task<IActionResult> JwtTokenProvider()
    {
        var token = await _tutorial.ProvideJwtToken();
        return Ok(token);
    }

    [HttpGet("QuickOrderBody")]
    public async Task<IActionResult> OrderCreateDto(CancellationToken cancellationToken)
    {
        var request = await _tutorial.GenerateOrderCreateDtoAsync(
            "ZOVeglC_pUm23GPfH972qA", "843e5834-b805-4b25-817c-349bb37f0149",
            cancellationToken, new TutorialOrderCreateDto[2]
            {
                    new()
                    {
                        ProductId = "MoeljLg-5EO8NWZktzh8Mg",
                        Quantity = 1
                    },
                    new()
                    {
                        ProductId = "ijh_R4Pm20KKAeVu2S8PYQ",
                        Quantity = 1
                    }
            });
        return Ok(request);
    }

    [Authorize]
    [HttpPost("OrderCreateDto:Helper/")]
    public async Task<IActionResult> OrderCreateDtoHelper([FromBody] OrderCreateDtoHelper orderCreateDtoHelper, CancellationToken cancellationToken)
    {
        var (isValid, errorDictionary)=await _tutorial.ValidateModelOrderCreateDtoHelper(orderCreateDtoHelper);
        if (!isValid)
        {
            foreach (var (key, value) in errorDictionary)
                ModelState.AddModelError(key, value);
            return BadRequest(ModelState);
        }

        var request = await _tutorial.GenerateOrderCreateDtoAsync(orderCreateDtoHelper.storeId,
            orderCreateDtoHelper.customerId, cancellationToken, orderCreateDtoHelper.TutorialOrderCreateDto.ToArray());
        return Ok(request);
    }

    [HttpGet("CodeInformation")]
    public IActionResult CodeInformation()
    {
        return Ok(
            @"
        'This Api was developed with:'
            Net 6 / .Net Core 6
            Entity framework core 6, Code-first
            NUnit 3  & Moq 4
            AutoMapper 11
            Jwt bearer Tokens
            RabbitMq Client 6
            Swashbuckle 6
            NewtonSoft JsonConverter            
            
            'Other:'
            Solid design principles (although, for something this size, YAGNI, KISS and very hard to break)
            Data Annotations [models attributes]
            Ef core fluent apis [On Order Delete: Cascading Behaviors]
            Code First
            Custom validations
            Defensive coding
            SQL seeding the Database initial model data
            Response Model Pattern
            Repository Pattern (Generic),
            RabbitMq Message Queue Consumer.
            C# Naming conventions: 
                exception: 
                            Named Arguments for method parameters, especially when using the Repository, example ahead:
                            'Method parameter: with Named Argument'
                            includes: new Expression<Func<Order, object>>[]
                            {
                                include => include.OrderItems,
                                include => include.OrderStatuses,
                                include => include.Payments
                            });
                            'Method parameter: without Named Argument'
                                include => include.OrderItems,
                                include => include.OrderStatuses,
                                include => include.Payments

        Thank you for your time.
        'Developed by Paul E. Sanchez C.'
                ");
    }
}


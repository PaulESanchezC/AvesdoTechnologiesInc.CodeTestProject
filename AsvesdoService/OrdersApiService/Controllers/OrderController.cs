using System.Globalization;
using System.Web;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.OrderModels;
using Models.ResponseModels;
using Models.ResponseModels.ResponseTemplates;
using Services.Repository.OrderRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Dependencies, Constructor
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion
        
        
        /// <param name="storeId">Store Identifier</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400"><mark>Bad Request</mark> : storeId is a required field .</response>
        [ProducesResponseType(typeof(Response<OrderDto>),200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllOrdersForStore/{storeId}")]
        public async Task<IActionResult> GetAllOrdersForStore(string storeId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                ModelState.AddModelError("storeId", "The storeId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetAllByAsync(
                predicate: order => order.StoreId == storeId,
                orderBy: order => order.OrderDateAndTime,
                cancellationToken: cancellationToken,
                //Entities EfCore Includes
                include => include.OrderStatus, include => include.Customer, include => include.Payments,
                include => include.OrderType, include => include.OrderItems);

            return StatusCode(request.StatusCode,request);
        }


        /// <param name="storeId">Store Identifier</param>
        /// <param name="dateRequest">Date requested, as text in format: <mark> MM-dd-yyyy </mark></param>
        /// <param name="cancellationToken"></param>
        /// <response code="400"><mark>Bad Request</mark> : storeId and dateRequest are required field .</response>
        /// <response code="400"><mark>Bad Request</mark> :  dateRequest invalid date format.</response>
        [ProducesResponseType(typeof(Response<OrderDto>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("FindAllOrdersForStoreByDate/{storeId}/{dateRequest}")]
        public async Task<IActionResult> FindAllOrdersForStoreByDate(string storeId, string dateRequest, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                ModelState.AddModelError("storeId", "The storeId field is required.");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(dateRequest))
            {
                ModelState.AddModelError("dateRequest", "The dateRequest field is required.");
                return BadRequest(ModelState);
            }
            if (!DateTime.TryParseExact(HttpUtility.UrlDecode(dateRequest), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOfRequestParsed))
            {
                ModelState.AddModelError("dateOfRequestString", "dateOfRequestString: Invalid date format, the format must be MM-dd-yyyy.");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetAllByAsync(
                predicate: order => order.StoreId == storeId &&
                                    order.OrderDateAndTime == dateOfRequestParsed,
                orderBy: order => order.OrderDateAndTime,
                cancellationToken: cancellationToken,
                //Entities EfCore Includes
                include => include.OrderStatus, include => include.Customer, include => include.Payments,
                include => include.OrderType, include => include.OrderItems);

            return StatusCode(request.StatusCode, request);
        }


        /// <param name="storeId">Store Identifier</param>
        /// <param name="orderId">Order Identifier</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400"><mark>Bad Request</mark> : storeId and orderId are required field .</response>
        [ProducesResponseType(typeof(Response<OrderDto>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetSingleOrderForStore/{storeId}/{orderId}")]
        public async Task<IActionResult> GetSingleOrdersForStore(string storeId, string orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                ModelState.AddModelError("storeId", "The storeId field is required.");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(orderId))
            {
                ModelState.AddModelError("orderId", "The orderId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetSingleByAsync(
                predicate: order => order.StoreId == storeId &&
                                    order.OrderId == orderId,
                cancellationToken: cancellationToken,
                //Entities EfCore Includes
                include => include.OrderStatus, include => include.Customer, include => include.Payments,
                include => include.OrderType, include => include.OrderItems);

            return StatusCode(request.StatusCode, request);
        }


        /// <param name="orderToCreate"><mark>*required</mark> : Takes a type of OrderCreateDto serialized in the body </param>
        /// <param name="cancellationToken"></param>
        /// <response code="400"><mark>Bad Request</mark> : orderToCreate modelState invalid.</response>
        [ProducesResponseType(typeof(Response<OrderDto>), 201)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost("MakeAnOrder")]
        public async Task<IActionResult> MakeAnOrder([FromBody] OrderCreateDto orderToCreate, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _orderRepository.CreateAsync(orderToCreate, cancellationToken);
            return StatusCode(request.StatusCode,request);
        }

    }
}

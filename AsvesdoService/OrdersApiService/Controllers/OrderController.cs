using System.Globalization;
using System.Web;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.EnumModels;
using Models.OrderModels;
using Models.ResponseModels;
using Models.StoreModels;
using Services.Repository.OrderRepository;

namespace ApiOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet("GetAllOrdersWithPagination/{pageSize:int}/{currentPage:int}")]
        public async Task<IActionResult> GetAllOrdersWithPagination(int pageSize, int currentPage, CancellationToken cancellationToken)
        {
            if (pageSize<=0)
            {
                ModelState.AddModelError("pageSize","Invalid pageSize Value, pageSize must be > 0 (zero)");
                return BadRequest(ModelState);
            }
            if (currentPage <= 0)
            {
                ModelState.AddModelError("currentPage", "Invalid currentPage Value, currentPage must be > 0 (zero)");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetAllWithPagesAsync(pageSize, currentPage,null, orderBy => orderBy.OrderDateAndTime,cancellationToken,
                include => include.OrderStatuses.OrderBy(status => status.StatusDate), include => include.Customer, include => include.Payments,
                include => include.Store, include => include.OrderItems);
            return StatusCode(request.StatusCode, request);
        }

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
                include => include.OrderStatuses.OrderBy(status => status.StatusDate), include => include.Customer, include => include.Payments,
                include => include.Store, include => include.OrderItems);

            return StatusCode(request.StatusCode, request);
        }

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
                include => include.OrderStatuses.OrderBy(status => status.StatusDate), include => include.Customer, include => include.Payments,
                include => include.Store, include => include.OrderItems);

            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetSingleOrder/{orderId}")]
        public async Task<IActionResult> GetSingleOrdersForStore(string orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                ModelState.AddModelError("orderId", "The orderId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetSingleByAsync(
                predicate: order => order.OrderId == orderId,
                cancellationToken: cancellationToken,
                //Entities EfCore Includes
                include => include.OrderStatuses.OrderBy(status => status.StatusDate), include => include.Customer, include => include.Payments,
                include => include.Store, include => include.OrderItems);

            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllOrdersForCustomer/{customerId}")]
        public async Task<IActionResult> GetAllOrdersForCustomer(string customerId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                ModelState.AddModelError("customerId", "The customerId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.GetAllByAsync(
                order => order.CustomerId == customerId,
                orderBy => orderBy.OrderDateAndTime,
                cancellationToken,
                include => include.OrderItems, include => include.OrderStatuses, include => include.Payments);
            return StatusCode(request.StatusCode, request);
        }


        [Authorize]
        [HttpPost("MakeAnOrder")]
        public async Task<IActionResult> MakeAnOrder([FromBody] OrderCreateDto orderToCreate, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var (isModelValid, errorDictionary) = await _orderRepository.ValidateOrderTypeAndPaymentMethodModelStateTask(orderToCreate, cancellationToken);
            if (!isModelValid)
            {
                foreach (var (key, value) in errorDictionary)
                    ModelState.AddModelError(key,value);
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.CreateAsync(orderToCreate, cancellationToken);
            if (request.IsSuccessful)
            {
                request = await _orderRepository.SetOrderStatusAsync(request.ResponseObject!.FirstOrDefault()!.OrderId,
                    OrderStatusTypes.Payed, cancellationToken);
                if (request.IsSuccessful)
                {
                    return StatusCode(request.StatusCode, request);
                }
            }
            return StatusCode(request.StatusCode, request);
        }

        [Authorize]
        [HttpPost("SetOrderStatus/{orderId}/{status}")]
        public async Task<IActionResult> SetOrderStatusTo(string orderId, string status, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                ModelState.AddModelError("orderId", "The orderId field is required.");
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(status))
            {
                ModelState.AddModelError("status","The status field is required.");
                return BadRequest(ModelState);
            }

            var (isStatusValid, error) = await _orderRepository.ValidateOrderStatusTypeModelStateTask(status, cancellationToken);
            if (!isStatusValid)
            {
                ModelState.AddModelError(error.Key, error.Value);
                return BadRequest(ModelState);
            }

            var request = await _orderRepository.SetOrderStatusAsync(orderId, status, cancellationToken);
            return StatusCode(request.StatusCode,request);

        }
    }
}

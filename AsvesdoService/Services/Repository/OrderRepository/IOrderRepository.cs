using Models.OrderModels;
using Models.ResponseModels;

namespace Services.Repository.OrderRepository;

public interface IOrderRepository : IRepository<Order,OrderDto, OrderCreateDto, OrderUpdateDto>
{
    Task<Response<OrderDto>> SetOrderStatusAsync(string orderId, string orderStatus, CancellationToken cancellationToken);
    Task<(bool, Dictionary<string, string>)> ValidateOrderTypeAndPaymentMethodModelStateTask(OrderCreateDto orderCreateDto, CancellationToken cancellationToken);
    Task<(bool, KeyValuePair<string, string>)> ValidateOrderStatusTypeModelStateTask(string status, CancellationToken cancellationToken);
}
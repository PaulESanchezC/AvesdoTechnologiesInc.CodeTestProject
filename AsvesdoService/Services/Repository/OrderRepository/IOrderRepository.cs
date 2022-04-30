using Models.OrderModels;
using Models.ResponseModels;

namespace Services.Repository.OrderRepository;

public interface IOrderRepository : IRepository<OrderBase,OrderDto,OrderCreateDto,OrderUpdateDto>
{
}
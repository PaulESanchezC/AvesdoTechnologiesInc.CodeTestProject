using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Models.EnumModels;
using Models.OrderItemModels;
using Models.OrderModels;
using Models.OrderStatusesModels;
using Models.PaymentModels;
using Models.ResponseModels;

namespace Services.Repository.OrderRepository;

public class OrderRepository : Repository<Order, OrderDto, OrderCreateDto, OrderUpdateDto>, IOrderRepository
{
    private readonly ApplicationDbContext _db;
    
    public OrderRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
    }


    public async Task<Response<OrderDto>> SetOrderStatusAsync(string orderId, string orderStatus, CancellationToken cancellationToken)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId, cancellationToken);
        var orderStatusToCreate = new OrderStatus
        {
            Orders = new() { order! },
            Status = orderStatus
        };

        var entity = await _db.OrderStatuses.AddAsync(orderStatusToCreate, cancellationToken);
        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 300, "Operation Incomplete", "The Order has been successfully created but no the server failed to set the order status, please do so manually!", order);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 300, "Operation Incomplete", "The Order has been successfully created but no the server failed to set the order status, please do so manually!", order);
        }

        order = await _db.Orders.Include(o => o.OrderStatuses.OrderBy(by => by.StatusDate))
            .Include(o => o.Payments)
            .Include(o => o.Customer)
            .Include(o => o.Store)
            .Include(o => o.Store.Tax)
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(prop => prop.OrderId == orderId, cancellationToken);

        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", order); ;
    }
    public Task<(bool, Dictionary<string, string>)> ValidateOrderTypeAndPaymentMethodModelStateTask(OrderCreateDto orderCreateDto, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var isValid = true;
        var errorDictionary = new Dictionary<string, string>();

        if (!OrderTypeTypes.OrderTypesList.Contains(orderCreateDto.OrderType))
        {
            isValid = false;
            errorDictionary.Add("Invalid OrderType value", $"The allowed values for OrderType are {string.Join(", ", OrderTypeTypes.OrderTypesList)}");
        }

        orderCreateDto.Payments.ForEach(payment =>
        {
            if (!PaymentMethodsTypes.PaymentMethodsList.Contains(payment.PaymentMethod))
            {
                isValid = false;
                errorDictionary.Add("Invalid PaymentMethod value",
                    $"The allowed values for PaymentMethod are {string.Join(", ", PaymentMethodsTypes.PaymentMethodsList)}");
            }
        });
        return Task.FromResult((isValid, errorDictionary));
    }
    public Task<(bool, KeyValuePair<string, string>)> ValidateOrderStatusTypeModelStateTask(string status, CancellationToken cancellationToken)
    {

        if (!OrderStatusTypes.OrderStatusTypesList.Contains(status))
            return Task.FromResult(
                (
                    false,
                    new KeyValuePair<string, string>
                    (
                        "Invalid status value",
                        $"The allowed values for OrderType are {string.Join(", ", OrderStatusTypes.OrderStatusTypesList)}")
                    )
                );

        return Task.FromResult((true, new KeyValuePair<string, string>("Ok", "Ok")));
    }
}

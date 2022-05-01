using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.EnumModels;
using Models.MessageQueueModels;
using Models.OrderModels;
using Models.OrderStatusesModels;
using Models.ResponseModels;
using Services.RabbitMqService;

namespace Services.Repository.OrderRepository;

public class OrderRepository : Repository<Order, OrderDto, OrderCreateDto, OrderUpdateDto>, IOrderRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IRabbitMqService _messageQueueService;
    public OrderRepository(ApplicationDbContext db, IMapper mapper, IRabbitMqService messageQueueService) : base(db, mapper)
    {
        _db = db;
        _messageQueueService = messageQueueService;
    }

    public async Task<Response<OrderDto>> SetOrderStatusAsync(string orderId, string orderStatus, bool isNewOrder, CancellationToken cancellationToken)
    {
        var order = await _db.Orders.Include(status => status.OrderStatuses)
            .FirstOrDefaultAsync(order => order.OrderId == orderId, cancellationToken);

        if (order is null)
            return await ResponseSingleBuilderTask(false, 404, "Empty Result", "There seems to be no order by the orderId provided", null);

        var lastStatus = order.OrderStatuses.OrderBy(by => by.StatusDate).FirstOrDefault();
        if (lastStatus.Status == OrderStatusTypes.Delivered || lastStatus.Status == OrderStatusTypes.Canceled)
            return await ResponseSingleBuilderTask(false, 404, "Invalid Operation", $"The order status is final: order status '{lastStatus.Status}' cannot be changed ", null);

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

        var message = isNewOrder
            ? new SalesQueueMessage { NewOrder = order }
            : new SalesQueueMessage { OrderUpdated = order };
        _messageQueueService.SendSalesQueueMessage(message);
        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", order);
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

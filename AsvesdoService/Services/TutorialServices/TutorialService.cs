using Data;
using Microsoft.EntityFrameworkCore;
using Models.EnumModels;
using Models.OrderItemModels;
using Models.OrderModels;
using Models.PaymentModels;
using Models.TutorialModels;
using Services.JwtServices;

namespace Services.TutorialServices;

public class TutorialService : ITutorialService
{
    private readonly IJwtServices _jwtServices;
    private readonly ApplicationDbContext _db;
    public TutorialService(IJwtServices jwtServices, ApplicationDbContext db)
    {
        _jwtServices = jwtServices;
        _db = db;
    }


    public async Task<string> ProvideJwtToken()
    {
        return await _jwtServices.GenerateTokenAsync();
    }

    public async Task<OrderCreateDto> GenerateOrderCreateDtoAsync(string storeId, string? customerId, CancellationToken cancellationToken,
        params TutorialOrderCreateDto[] products)
    {
        var store = await _db.Stores.Include(tax => tax.Tax)
            .FirstOrDefaultAsync(store => store.StoreId == storeId, cancellationToken);

        customerId ??= "a618dc4a-57b5-48f4-8699-4b30e1f9cfd7";

        var orderItemList = new List<OrderItemCreateDto>();
        var subTotal = 0.0;
        foreach (var item in products)
        {
            var product = await _db.Products.FirstOrDefaultAsync(prd => prd.ProductId == item.ProductId, cancellationToken);
            subTotal += product!.Price * item.Quantity;
            orderItemList.Add(new(){ProductId = item.ProductId,Quantity = item.Quantity});
        }

        var taxRates = 0.0;
        store!.Tax.ForEach(tax =>
        {
            taxRates += tax.TaxPercentage;
        });
        var taxesPayment = subTotal * (taxRates / 100);

        var paymentList = new List<PaymentCreateDto>()
        {
            new()
            {
                CustomerId = customerId,
                StoreId = storeId,
                TotalAmount = subTotal,
                PaymentMethod = PaymentMethodsTypes.Other,
                SubTotal = subTotal,
                TaxesAmount = taxesPayment
            }
        };

        var totalAmount = taxesPayment + subTotal;

        var orderCreate = new OrderCreateDto
        {
            CustomerId = customerId,
            StoreId = storeId,
            TotalAmount = totalAmount,
            OrderType = OrderTypeTypes.MobileApp,
            OrderItems = orderItemList,
            Payments = paymentList
        };

        return orderCreate;
    }

    public Task<(bool, Dictionary<string, string>)> ValidateModelOrderCreateDtoHelper(OrderCreateDtoHelper model)
    {
        var isValid = true;
        var errorDictionary = new Dictionary<string, string>();

        if (model.customerId is "string" || string.IsNullOrEmpty(model.customerId))
        {
            isValid = false;
            errorDictionary.Add("customerId","The customerId field is required.");
        }
        if (model.storeId is "string" || string.IsNullOrEmpty(model.storeId))
        {
            isValid = false;
            errorDictionary.Add("storeId", "The storeId field is required.");
        }

        return Task.FromResult((isValid, errorDictionary));
    }
}
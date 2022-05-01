using AutoMapper;
using Models.CustomerModels;
using Models.OrderItemModels;
using Models.OrderModels;
using Models.OrderStatusesModels;
using Models.PaymentModels;
using Models.ProductModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        CreateMap<OrderCreateDto, Order>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        
        CreateMap<PaymentCreateDto, Payment>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        
        CreateMap<OrderItemCreateDto, OrderItem>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        
        CreateMap<Tax, TaxDto>().ReverseMap();
        
        CreateMap<Customer, CustomerDto>().ReverseMap();
        
        CreateMap<Store, StoreDto>().ReverseMap();

        CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
    }
}

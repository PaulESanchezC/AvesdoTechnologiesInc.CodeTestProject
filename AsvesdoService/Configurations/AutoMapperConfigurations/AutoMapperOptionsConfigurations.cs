using AutoMapper;
using Models.OrderModels;

namespace Configurations.AutoMapperConfigurations;
public class AutoMapperOptionsConfigurations : Profile
{
    public AutoMapperOptionsConfigurations()
    {
        #region Orders Maps

        CreateMap<OrderCreateDto, OrderBase>();
        CreateMap<OrderUpdateDto, OrderBase>();
        CreateMap<OrderBase, OrderDto>();

        #endregion


    }
}
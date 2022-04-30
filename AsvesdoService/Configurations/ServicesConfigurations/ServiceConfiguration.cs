using Microsoft.Extensions.DependencyInjection;
using Services.Repository.OrderRepository;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}
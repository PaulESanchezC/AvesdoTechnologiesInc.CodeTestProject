using Microsoft.Extensions.DependencyInjection;
using Services.JwtServices;
using Services.Repository.OrderRepository;
using Services.Repository.StaffRepository;
using Services.TinyRepository.EmploymentRoleTinyRepository;
using Services.TinyRepository.ProductsTinyRepository;
using Services.TinyRepository.StoresTinyRepository;
using Services.TinyRepository.TaxTinyRepository;
using Services.TutorialServices;

namespace Configurations.ServicesConfigurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITaxRepository, TaxRepository>();
        services.AddScoped<IJwtServices, JwtServices>();
        services.AddScoped<ITutorialService, TutorialService>();
        services.AddScoped<IEmploymentRolesRepository, EmploymentRolesRepository>();
        services.AddScoped<IStaffRepository,StaffRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Configurations.JsonConfigurations;

public static class JsonConfiguration
{
    public static IServiceCollection AddJsonConfigurations(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNameCaseInsensitive = false)
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.MaxDepth = 3;
                options.SerializerSettings.DateFormatString = "MM-dd-yyyy";
            });
        return services;
    }
}
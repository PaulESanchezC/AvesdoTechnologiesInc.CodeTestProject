using Microsoft.Extensions.DependencyInjection;
using StaticData;

namespace Configurations.CorsConfigurations;

public static class CorsConfiguration
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(opt =>
            opt.AddPolicy(AvesdoApiConstants.CorsAnonymousPolicy, build =>
                build.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
        return services;
    }
}
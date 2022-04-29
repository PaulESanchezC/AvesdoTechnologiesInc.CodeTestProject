using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StaticData;

namespace Configurations.AuthorizationConfigurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationConfigurations(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerOptions.AuthenticationScheme).AddJwtBearer(JwtBearerOptions.AuthenticationScheme,
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
        return services;
    }
}
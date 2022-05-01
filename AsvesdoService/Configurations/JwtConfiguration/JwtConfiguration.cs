using System.Text;
using Configurations.ConfigurationsHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Models.Options;


namespace Configurations.JwtConfiguration;

public static class JwtConfiguration
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services)
    {
        services.Configure<JwtOptions>(ProxyConfiguration.Use.GetSection("JwtOptions"));

        var jwtSecretKey = ProxyConfiguration.Use.GetValue<string>("JwtOptions:SecretKey");

        var key = Encoding.ASCII.GetBytes(jwtSecretKey);

        services.AddAuthentication(schema =>
        {
            schema.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            schema.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            schema.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(bearer =>
        {
            bearer.RequireHttpsMetadata = true;
            bearer.SaveToken = true;
            bearer.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                RequireExpirationTime = false,
                ValidateLifetime = false,
                ValidateActor = false,

                RequireAudience = false,
                ValidateAudience = false,
                ValidateIssuer = false,
            };
        });
        return services;
    }

}
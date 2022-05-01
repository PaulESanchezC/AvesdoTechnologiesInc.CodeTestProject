using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.JsonConfigurations;
using Configurations.JwtConfiguration;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;
using StaticData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Services
//AutoMapper Configurations
builder.Services.AddAutoMapperMapConfigurations();
//Configuration Helper -ProxyConfiguration-
ProxyConfiguration.Initialize(builder.Configuration);
//Cors Configurations
builder.Services.AddCorsConfiguration();
//DataAccessConfigurations
builder.Services.AddDbContextOptions();
//Json Configurations
builder.Services.AddJsonConfigurations();
//SwaggerGen Configurations
builder.Services.AddSwaggerGenConfiguration();
//Services Configurations
builder.Services.AddServicesConfigurations();
builder.Services.AddMessageQueueServicesConfigurations();
//Jwt Configurations 
builder.Services.AddJwtConfiguration();
#endregion

var app = builder.Build();

#region Http request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/ApiOrderService/swagger.json", "Asvesdo Orders Api Service"));
    app.UseCors(AvesdoApiConstants.CorsAnonymousPolicy);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
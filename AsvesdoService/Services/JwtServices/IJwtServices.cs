namespace Services.JwtServices;

public interface IJwtServices
{
    Task<string> GenerateTokenAsync();
}
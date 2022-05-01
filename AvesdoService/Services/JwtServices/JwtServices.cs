using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Options;

namespace Services.JwtServices;

public class JwtServices : IJwtServices
{
    private readonly JwtOptions _jwtOptions;

    public JwtServices(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public async Task<string> GenerateTokenAsync()
    {
        var claims = await GenerateClaims();

        var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
        var symmetricSecurityKey = new SymmetricSecurityKey(key);
        var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddYears(15),
            SigningCredentials = signInCredentials,
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.UtcNow,
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private Task<List<Claim>> GenerateClaims()
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, "user.Id"),
            new (ClaimTypes.GivenName, "user.FirstName"),
            new (ClaimTypes.Surname, "user.LastName"),
            new (ClaimTypes.Email, "user.Email"),
            new (ClaimTypes.MobilePhone, "user.PhoneNumber"),
            new (ClaimTypes.StreetAddress, "user.Address"),
            new (ClaimTypes.Locality, "user.City"),
            new (ClaimTypes.StateOrProvince, "user.StateOrProvince"),
            new (ClaimTypes.Authentication, "hasPassword.ToString()"),
            new (ClaimTypes.Role, "user.Roles"),
        };
        return Task.FromResult(claims);
    }
}
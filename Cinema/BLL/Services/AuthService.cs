using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services;

public class AuthService: IAuthService
{
    private static TimeSpan TokenLifeTime = TimeSpan.FromHours(3);

    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var role = user.Role == UserRole.Administrator ? "admin" : "user";
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Jti, user.ID.ToString()),
            // new(JwtRegisteredClaimNames.UniqueName, user.Username),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Iss, _configuration.GetSection("Jwt")["ValidIssuer"]),
            new("admin", role)
        };
        var descriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.Add(TokenLifeTime),
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(descriptor);
        var jwt = tokenHandler.WriteToken(token);

        return jwt;
    }
}
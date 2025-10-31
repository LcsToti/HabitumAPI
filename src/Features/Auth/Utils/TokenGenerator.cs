using HabitumAPI.Features.Auth.Interfaces;
using HabitumAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HabitumAPI.Features.Auth.Utils;

public class TokenGenerator(IConfiguration configuration) : ITokenGenerator
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var secretKey = _configuration["JwtSettings:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("A chave secreta JWT não está configurada.");
        }

        var key = Encoding.ASCII.GetBytes(secretKey);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddDays(30),
            Audience = _configuration["JwtSettings:Audience"],
            Issuer = _configuration["JwtSettings:Issuer"]
        };
        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    public static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

        return claims;
    }
}

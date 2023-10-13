using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Usuarios.Colaboradores;
using Domain.Usuarios.Colaboradores.Services;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Usuarios.Colaboradores.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public bool ComparePassword(string password, string passwordHashed)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
    }

    public string EncryptPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public string GenerateToken(Colaborador colaborador)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, $"{colaborador.Nombres} {colaborador.Apellidos}"),
            new Claim(ClaimTypes.Email, colaborador.EmailAcceso)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value)
        );
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }
}

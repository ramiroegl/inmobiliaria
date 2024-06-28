using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Domain.Shared;
using Inmobiliaria.Infrastructure.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Inmobiliaria.Infrastructure.Users;

public class TokenService(IOptions<SignatureOptions> options, ITimeProvider timeProvider)
{
    public string Generate(UserDto user)
    {
        var handler = new JwtSecurityTokenHandler();
        SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(user);
        SecurityToken? token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    /// <summary>
    /// get token descriptor for generate token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private SecurityTokenDescriptor GetTokenDescriptor(UserDto user)
    {
        var claimsIdentity = new ClaimsIdentity([
            new Claim("user_id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("role", user.Role.ToString())
        ]);

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(options.Value.SymmetricKey));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = timeProvider.Now.Add(options.Value.SignatureLifetime).UtcDateTime,
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        };

        return tokenDescriptor;
    }
}

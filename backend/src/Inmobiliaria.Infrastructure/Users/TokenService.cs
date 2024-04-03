using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inmobiliaria.Application.Users;
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
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim(JwtRegisteredClaimNames.Iss, "Inmobiliaria"),
            new Claim(JwtRegisteredClaimNames.Aud, "Inmobiliaria"),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email)
        ]);

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(options.Value.SymmetricKey));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = timeProvider.Now.Add(options.Value.SignatureLifetime).UtcDateTime,
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256)
        };

        return tokenDescriptor;
    }
}

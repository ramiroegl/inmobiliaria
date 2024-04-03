using Inmobiliaria.Application.Users;

namespace Inmobiliaria.Api.Models;

public record LoginCredentials
{
    public required UserDto User { get; init; }
    public required string Token { get; init; }
}

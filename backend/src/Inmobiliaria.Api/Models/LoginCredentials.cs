using Inmobiliaria.Application.Users.Shared;

namespace Inmobiliaria.Api.Models;

public record LoginCredentials
{
    public required UserDto User { get; init; }
    public required string Token { get; init; }
}

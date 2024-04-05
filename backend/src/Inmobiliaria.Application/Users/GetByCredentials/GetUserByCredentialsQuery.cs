using Inmobiliaria.Application.Users.Shared;
using MediatR;

namespace Inmobiliaria.Application.Users.GetByCredentials;

public record GetUserByCredentialsQuery : IRequest<UserDto?>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}

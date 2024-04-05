using MediatR;

namespace Inmobiliaria.Application.Users.Create;

public record CreateUserCommand : IRequest<CreatedUserResult?>
{
    public required string Name { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}

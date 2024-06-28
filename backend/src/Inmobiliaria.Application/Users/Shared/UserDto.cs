using Inmobiliaria.Domain.Users;

namespace Inmobiliaria.Application.Users.Shared;

public record UserDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
}

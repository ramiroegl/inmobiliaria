namespace Inmobiliaria.Application.Users;

public record UserDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
}

using Inmobiliaria.Domain.Users;
using MediatR;

namespace Inmobiliaria.Application.Users.Update;

public record UpdateUserCommand : IRequest<UpdatedUserResult?>
{
    public required Guid UserId { get; set; }
    public required string Name { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
}

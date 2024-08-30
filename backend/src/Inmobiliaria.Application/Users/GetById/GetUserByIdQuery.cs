using MediatR;

namespace Inmobiliaria.Application.Users.GetById;

public record GetUserByIdQuery : IRequest<UserByIdResult?>
{
    public required Guid Id { get; set; }
}

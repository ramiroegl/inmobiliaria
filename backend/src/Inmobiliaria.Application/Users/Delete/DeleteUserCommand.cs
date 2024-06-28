using MediatR;

namespace Inmobiliaria.Application.Users.Delete;

public record DeleteUserCommand(Guid Id) : IRequest<DeletedUserResult>;

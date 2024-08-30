using MediatR;

namespace Inmobiliaria.Application.Users.ChangePassword;

public record ChangePasswordCommand : IRequest<ChangedPasswordResult?>
{
    public required Guid Id { get; init; }
    public required string NewPassword { get; init; }
}

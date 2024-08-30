using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Users;
using MediatR;

namespace Inmobiliaria.Application.Users.ChangePassword;

public class ChangePasswordHandler(IUserRepository userRepository, IHasher hasher) : IRequestHandler<ChangePasswordCommand, ChangedPasswordResult?>
{
    public async Task<ChangedPasswordResult?> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.NewPassword))
        {
            return null;
        }

        User? user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return null;
        }

        user.Password = hasher.Hash(request.NewPassword);
        await userRepository.UpdateAsync(user, cancellationToken);

        return new ChangedPasswordResult();
    }
}

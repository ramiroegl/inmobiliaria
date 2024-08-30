using Inmobiliaria.Domain.Users;
using MediatR;

namespace Inmobiliaria.Application.Users.Update;

public class UpdateUserHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, UpdatedUserResult?>
{
    public async Task<UpdatedUserResult?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return null;
        }

        user.Email = request.Email;
        user.Name = request.Name;
        user.LastName = request.LastName;
        user.UpdatedOn = DateTime.UtcNow;
        user.Role = request.Role;

        await userRepository.UpdateAsync(user, cancellationToken);

        return new UpdatedUserResult();
    }
}

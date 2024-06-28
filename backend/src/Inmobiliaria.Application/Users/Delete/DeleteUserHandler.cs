using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Users;
using MediatR;

namespace Inmobiliaria.Application.Users.Delete;

public class DeleteUserHandler(IMapper mapper, IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, DeletedUserResult>
{
    public async Task<DeletedUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return new DeletedUserResult(Ok: false, Error: "El usuario no existe.");
        }

        if (user.Role is Role.Admin)
        {
            return new DeletedUserResult(Ok: false, Error: "El usuario no puede eliminarse.");
        }

        await userRepository.DeleteAsync(user, cancellationToken);
        DeletedUserResult result = mapper.ToDeletedUser(user);

        return result;
    }
}

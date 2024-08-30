using Inmobiliaria.Domain.Users;
using MediatR;

namespace Inmobiliaria.Application.Users.GetById;

public class GetUserByIdHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserByIdResult?>
{
    public async Task<UserByIdResult?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
        {
            return null;
        }

        return (UserByIdResult)user;
    }
}

using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Users;
using Inmobiliaria.Domain.Users.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Users.Create;

public class CreateUserHandler(IUserRepository userRepository, IHasher hasher) : IRequestHandler<CreateUserCommand, CreatedUserResult?>
{
    public async Task<CreatedUserResult?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool userAlreadyExists = await userRepository.AnyAsync(new UserByEmailSpec(request.Email), cancellationToken);
        if (userAlreadyExists)
        {
            return null;
        }

        User user = new()
        {
            Email = request.Email,
            LastName = request.LastName,
            Name = request.Name,
            Password = hasher.Hash(request.Password),
            Role = Role.User
        };

        await userRepository.AddAsync(user, cancellationToken);

        return new CreatedUserResult { Id = user.Id };
    }
}

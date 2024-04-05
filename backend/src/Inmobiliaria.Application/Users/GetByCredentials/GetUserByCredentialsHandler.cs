using Inmobiliaria.Application.Shared;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Domain.Users;
using Inmobiliaria.Domain.Users.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Users.GetByCredentials;

public class GetUserByCredentialsHandler(IUserRepository userRepository, IHasher hasher) : IRequestHandler<GetUserByCredentialsQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
    {
        UserByEmailSpec specification = new(request.Email);
        User? user = await userRepository.SingleOrDefaultAsync(specification, cancellationToken);
        if (user is null)
        {
            return null;
        }

        var areValidCredentials = hasher.Verify(user.Password, request.Password);
        if (!areValidCredentials)
        {
            return null;
        }

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            LastName = user.LastName,
            Name = user.Name,
        };
    }
}

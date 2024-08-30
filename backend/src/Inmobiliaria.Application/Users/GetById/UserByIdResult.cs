using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Domain.Users;

namespace Inmobiliaria.Application.Users.GetById;

public record UserByIdResult : UserDto
{
    public static explicit operator UserByIdResult(User user) => new()
    {
        Id = user.Id,
        Email = user.Email,
        Name = user.Name,
        LastName = user.LastName,
        Role = user.Role
    };
}

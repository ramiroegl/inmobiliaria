using Inmobiliaria.Application.Shared;
using Inmobiliaria.Application.Users.Shared;

namespace Inmobiliaria.Application.Users.List;

public record ListedUsersResult : PaginatedResult<UserDto>;

using Inmobiliaria.Application.Shared;
using MediatR;

namespace Inmobiliaria.Application.Users.List;

public record ListUsersQuery : PaginatedQuery, IRequest<ListedUsersResult>
{
    public string? Search { get; init; }
}

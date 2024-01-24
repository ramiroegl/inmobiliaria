using Inmobiliaria.Application.Shared;
using MediatR;

namespace Inmobiliaria.Application.Customers.List;

public record ListCustomersQuery : PaginatedQuery, IRequest<ListedCustomersResult>
{
    public string? Search { get; init; }
}

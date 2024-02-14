using Inmobiliaria.Application.Shared;
using MediatR;

namespace Inmobiliaria.Application.Sales.List;

public record ListSalesQuery : PaginatedQuery, IRequest<ListedSalesResult>
{
    public string? Search { get; init; }
}

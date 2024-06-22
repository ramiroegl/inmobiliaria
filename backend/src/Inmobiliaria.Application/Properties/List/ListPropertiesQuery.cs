using Inmobiliaria.Application.Shared;
using MediatR;

namespace Inmobiliaria.Application.Properties.List;

public record ListPropertiesQuery : PaginatedQuery, IRequest<ListedPropertiesResult>
{
    public string? Search { get; init; }
}

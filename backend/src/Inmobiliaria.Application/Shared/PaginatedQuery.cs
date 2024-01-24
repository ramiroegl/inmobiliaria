namespace Inmobiliaria.Application.Shared;

public record PaginatedQuery
{
    public required int Skip { get; init; }
    public required int Take { get; init; }
}

namespace Inmobiliaria.Application.Shared;

public record PaginatedQuery
{
    public required int Skip { get; init; } = 0;
    public required int Take { get; init; } = 10;
}

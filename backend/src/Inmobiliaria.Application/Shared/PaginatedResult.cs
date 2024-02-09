namespace Inmobiliaria.Application.Shared;

public record PaginatedResult<T>
{
    public required IEnumerable<T> Data { get; init; }
    public required int TotalRecords { get; init; }
    public int TotalPages => ((TotalRecords - 1) / PageSize) + 1;
    public required int PageSize { get; init; }
}

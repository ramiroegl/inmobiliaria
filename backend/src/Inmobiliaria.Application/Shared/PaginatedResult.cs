namespace Inmobiliaria.Application.Shared;

public record PaginatedResult<T>
{
    public required int TotalRecords { get; init; }
    public int TotalPages => (int)((double)(TotalRecords - 1) / PageSize) + 1;
    public required int PageSize { get; init; }
    public required IEnumerable<T> Data { get; init; }
}

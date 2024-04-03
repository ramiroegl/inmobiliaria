using Inmobiliaria.Domain.Properties;

namespace Inmobiliaria.Application.Customers.GetByTuition;

public record PropertyByTuitionResult
{
    public required Guid Id { get; init; }
    public required string Tuition { get; init; }
    public required decimal Price { get; init; }
    public required Coordinates Coordinates { get; init; }
    public required string Block { get; init; }
    public required string Lot { get; init; }
}

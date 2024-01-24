using Inmobiliaria.Domain.Properties;
using MediatR;

namespace Inmobiliaria.Application.Properties.Create;

public record CreatePropertyCommand : IRequest<CreatedPropertyResult>
{
    public required decimal Value { get; init; }
    public required Coordinates Coordinates { get; init; }
    public required string Tuition { get; init; }
    public required string Block { get; init; }
    public required string Lot { get; init; }
}
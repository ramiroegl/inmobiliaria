using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class VisitData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool Visit { get; set; }
    public required bool Certified { get; set; }
    public required bool SentAfiniaDocuments { get; set; }
}

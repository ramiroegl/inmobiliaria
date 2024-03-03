using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class DeedCostsData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required Amount DeedCosts { get; set; }
    public required Amount NotaryPayment { get; set; }
    public required Amount PropertyPayment { get; set; }
    public required Amount GovernmentPayment { get; set; }
    public required Amount PublicInstrumentsPayment { get; set; }
    public required Amount DeedDebt { get; set; }
}

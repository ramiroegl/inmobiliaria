using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class DeliveryData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool ScannedDeliveryCertificate { get; set; }
    public required bool ScannedTaxAndRegistrationSlip { get; set; }
    public required bool ScannedDeed { get; set; }
    public required bool DisbursementInstruction { get; set; }
    public required bool PeaceAndSafetyPropertySeller { get; set; }
    public required bool ScannedCTL { get; set; }
    public required bool DeedSentToLawyer { get; set; }
}

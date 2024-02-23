using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class DocumentaryData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool IdentificationDocument { get; set; }
    public required bool SignedPledge { get; set; }
    public required bool CreditApprovalLetter { get; set; }
    public required string ApprovalLetterNumber { get; set; }
    public required string CompensationFundRecordNumber { get; set; }
    public required bool MinistrySubsidyResolution { get; set; }
    public required bool DeliveryDocument { get; set; }
}

using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class SaleDocumentaryData : Entity
{
    public SaleDocumentaryData(bool identificationDocument, bool signedPledge, bool creditApprovalLetter, bool approvalLetterNumber, bool compensationFundRecordNumber, bool ministrySubsidyResolution, bool deliveryDocument)
    {
        IdentificationDocument = identificationDocument;
        SignedPledge = signedPledge;
        CreditApprovalLetter = creditApprovalLetter;
        ApprovalLetterNumber = approvalLetterNumber;
        CompensationFundRecordNumber = compensationFundRecordNumber;
        MinistrySubsidyResolution = ministrySubsidyResolution;
        DeliveryDocument = deliveryDocument;
    }

    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public bool IdentificationDocument { get; set; }
    public bool SignedPledge { get; set; }
    public bool CreditApprovalLetter { get; set; }
    public bool ApprovalLetterNumber { get; set; }
    public bool CompensationFundRecordNumber { get; set; }
    public bool MinistrySubsidyResolution { get; set; }
    public bool DeliveryDocument { get; set; }
}

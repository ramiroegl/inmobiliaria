using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class AppraisalData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool Payment { get; set; }
    public required bool RequestSubmissionOfDocuments { get; set; }
    public required bool Visit { get; set; }
    public required bool Report { get; set; }
    public required bool IssuanceByTheBankOfALetterOfRatification { get; set; }
    public required bool TitleStudyPayment { get; set; }
    public required bool SendingDocumentsForTitleStudy { get; set; }
    public required string FamilyCodeInMinistryOfHousing { get; set; }
}

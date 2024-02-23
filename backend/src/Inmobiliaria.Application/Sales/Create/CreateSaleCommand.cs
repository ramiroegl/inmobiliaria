using Inmobiliaria.Application.Shared.DTOs;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using MediatR;

namespace Inmobiliaria.Application.Sales.Create;

public record CreateSaleCommand : IRequest<CreatedSaleResult>
{
    public required CreateSaleCustomerDto Customer { get; init; }
    public required CreateSalePropertyDto Property { get; init; }
    public required CreateFinancialDataDto FinancialData { get; init; }
    public required CreateDocumentaryDataDto DocumentaryData { get; init; }
    public required CreateAppraisalDataDto AppraisalData { get; init; }
    public required CreateDeedDataDto DeedData { get; init; }

    public record CreateSaleCustomerDto
    {
        public required string Email { get; init; }
        public required string Names { get; init; }
        public required string LastNames { get; init; }
        public required IdentityDto Identity { get; init; }
        public required CivilStatus CivilStatus { get; init; }
        public required decimal Salary { get; init; }
        public required string PhoneNumber { get; init; }
    }

    public record CreateSalePropertyDto
    {
        public required decimal Price { get; init; }
        public required Coordinates Coordinates { get; init; }
        public required string Tuition { get; init; }
        public required string Block { get; init; }
        public required string Lot { get; init; }
    }

    public record CreateFinancialDataDto
    {
        public required decimal Price { get; init; }
        public required decimal ValueToSetAside { get; init; }
        public required decimal OtherPayments { get; init; }
        public required decimal CompensationFundSubsidy { get; init; }
        public required decimal MinistryOfHousingSubsidy { get; init; }
        public required decimal LoanValue { get; init; }
        public required string LoanEntity { get; init; }
        public required decimal Debt { get; init; }
    }

    public record CreateDocumentaryDataDto
    {
        public required bool IdentificationDocument { get; init; }
        public required bool SignedPledge { get; init; }
        public required bool CreditApprovalLetter { get; init; }
        public required string ApprovalLetterNumber { get; init; }
        public required string CompensationFundRecordNumber { get; init; }
        public required bool MinistrySubsidyResolution { get; init; }
        public required bool DeliveryDocument { get; init; }
    }

    public record CreateAppraisalDataDto
    {
        public required bool Payment { get; init; }
        public required bool RequestSubmissionOfDocuments { get; init; }
        public required bool Visit { get; init; }
        public required bool Report { get; init; }
        public required bool IssuanceByTheBankOfALetterOfRatification { get; init; }
        public required bool TitleStudyPayment { get; init; }
        public required bool SendingDocumentsForTitleStudy { get; init; }
        public required string FamilyCodeInMinistryOfHousing { get; init; }
    }

    public record CreateDeedDataDto
    {
        public required bool ConstructionCompanySignature { get; init; }
        public required bool CustomerSignature { get; init; }
        public required bool PropertySellerSignature { get; init; }
        public required bool CopiesAndSettlement { get; init; }
        public required DateTimeOffset EntryDateIntoPublicInstruments { get; init; }
    }
}

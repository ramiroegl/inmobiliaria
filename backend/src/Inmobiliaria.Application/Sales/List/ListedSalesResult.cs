using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;

namespace Inmobiliaria.Application.Sales.List;

public record ListedSalesResult : PaginatedResult<ListedSalesResult.ListedSaleDto>
{
    public record ListedSaleDto
    {
        public required Guid Id { get; init; }
        public required ListedSaleCustomerDto Customer { get; init; }
        public required ListedSalePropertyDto Property { get; init; }
        public required ListedSaleFinancialDataDto FinancialData { get; init; }
        public required ListedSaleDocumentaryDataDto DocumentaryData { get; init; }
        public required ListedSaleAppraisalDataDto AppraisalData { get; init; }
        public required ListedSaleDeedDataDto DeedData { get; init; }
        public required ListedDeedCostsDataDto DeedCostsData { get; init; }
        public required ListedDeliveryDataDto DeliveryData { get; init; }
        public required ListedSubsidyDataDto SubsidyData { get; init; }
        public required ListedServicesDataDto ServicesData { get; init; }
        public required ListedVisitDataDto VisitData { get; init; }
        public required DateTimeOffset CreatedOn { get; init; }
        public required DateTimeOffset UpdatedOn { get; init; }

        public record ListedSaleCustomerDto
        {
            public required Guid CustomerId { get; init; }
            public required Identity Identity { get; init; }
            public required string Email { get; init; }
            public required string Names { get; init; }
            public required string LastNames { get; init; }
            public required CivilStatus CivilStatus { get; init; }
            public required decimal Salary { get; init; }
            public required string PhoneNumber { get; init; }
        }

        public record ListedSalePropertyDto
        {
            public required Guid PropertyId { get; init; }
            public required string Tuition { get; init; }
            public required decimal Price { get; init; }
            public required Coordinates Coordinates { get; init; }
            public required string Block { get; init; }
            public required string Lot { get; init; }
        }

        public record ListedSaleFinancialDataDto
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

        public record ListedSaleDocumentaryDataDto
        {
            public required bool IdentificationDocument { get; init; }
            public required bool SignedPledge { get; init; }
            public required bool CreditApprovalLetter { get; init; }
            public required string ApprovalLetterNumber { get; init; }
            public required string CompensationFundRecordNumber { get; init; }
            public required bool MinistrySubsidyResolution { get; init; }
            public required bool DeliveryDocument { get; init; }
        }

        public record ListedSaleAppraisalDataDto
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

        public record ListedSaleDeedDataDto
        {
            public required bool ConstructionCompanySignature { get; init; }
            public required bool CustomerSignature { get; init; }
            public required bool PropertySellerSignature { get; init; }
            public required bool CopiesAndSettlement { get; init; }
            public required DateOnly EntryDateIntoPublicInstruments { get; init; }
        }

        public record ListedDeedCostsDataDto
        {
            public required decimal DeedCosts { get; init; }
            public required decimal NotaryPayment { get; init; }
            public required decimal PropertyPayment { get; init; }
            public required decimal GovernmentPayment { get; init; }
            public required decimal PublicInstrumentsPayment { get; init; }
            public required decimal DeedDebt { get; init; }
        }

        public record ListedDeliveryDataDto
        {
            public required bool ScannedDeliveryCertificate { get; init; }
            public required bool ScannedTaxAndRegistrationSlip { get; init; }
            public required bool ScannedDeed { get; init; }
            public required bool DisbursementInstruction { get; init; }
            public required bool PeaceAndSafetyPropertySeller { get; init; }
            public required bool ScannedCTL { get; init; }
            public required bool DeedSentToLawyer { get; init; }
        }

        public record ListedSubsidyDataDto
        {
            public required bool DialedMinistryCollection { get; init; }
            public required bool MinistryPayment { get; init; }
            public required bool CompensationBoxSubsidyFiled { get; init; }
            public required bool CompensationCashPayment { get; init; }
            public required DateOnly LoanDisbursementDate { get; init; }
        }

        public record ListedServicesDataDto
        {
            public required decimal ElectricMeterValue { get; init; }
            public required bool InstalledElectricMeter { get; init; }
            public required bool InstalledWaterMeter { get; init; }
        }

        public record ListedVisitDataDto
        {
            public required bool Visit { get; init; }
            public required bool Certified { get; init; }
            public required bool SentAfiniaDocuments { get; init; }
        }
    }
}

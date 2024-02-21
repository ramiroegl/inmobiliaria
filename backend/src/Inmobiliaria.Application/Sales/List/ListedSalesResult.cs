using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;

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
        public required DateTimeOffset CreatedOn { get; set; }
        public required DateTimeOffset UpdatedOn { get; set; }

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
            public bool IdentificationDocument { get; init; }
            public bool SignedPledge { get; init; }
            public bool CreditApprovalLetter { get; init; }
            public bool ApprovalLetterNumber { get; init; }
            public bool CompensationFundRecordNumber { get; init; }
            public bool MinistrySubsidyResolution { get; init; }
            public bool DeliveryDocument { get; init; }
        }
    }
}

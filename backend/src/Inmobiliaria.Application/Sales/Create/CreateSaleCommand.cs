using Inmobiliaria.Application.Shared.DTOs;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using MediatR;

namespace Inmobiliaria.Application.Sales.Create;

public record CreateSaleCommand : IRequest<CreatedSaleResult>
{
    public required CreateSaleCustomerDto Customer { get; init; }
    public required CreateSalePropertyDto Property { get; init; }
    public required CreateSaleFinancialDataDto FinancialData { get; init; }
    public required CreateSaleDocumentaryDataDto DocumentaryData { get; init; }

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

    public record CreateSaleFinancialDataDto
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

    public record CreateSaleDocumentaryDataDto
    {
        public required bool IdentificationDocument { get; init; }
        public required bool SignedPledge { get; init; }
        public required bool CreditApprovalLetter { get; init; }
        public required bool ApprovalLetterNumber { get; init; }
        public required bool CompensationFundRecordNumber { get; init; }
        public required bool MinistrySubsidyResolution { get; init; }
        public required bool DeliveryDocument { get; init; }
    }
}

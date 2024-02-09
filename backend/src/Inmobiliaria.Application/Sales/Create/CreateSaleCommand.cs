using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using MediatR;

namespace Inmobiliaria.Application.Sales.Create;

public record CreateSaleCommand : IRequest<CreatedSaleResult>
{
    public required CustomerDto Customer { get; init; }
    public required PropertyDto Property { get; init; }
    public required FinancialDataDto FinancialData { get; init; }

    public record CustomerDto
    {
        public required string Email { get; init; }
        public required string Names { get; init; }
        public required string LastNames { get; init; }
        public required Identity Identity { get; init; }
        public required CivilStatus CivilStatus { get; init; }
        public required decimal Salary { get; init; }
        public required string PhoneNumber { get; init; }
    }

    public record PropertyDto
    {
        public required decimal Price { get; init; }
        public required Coordinates Coordinates { get; init; }
        public required string Tuition { get; init; }
        public required string Block { get; init; }
        public required string Lot { get; init; }
    }

    public record FinancialDataDto
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
}

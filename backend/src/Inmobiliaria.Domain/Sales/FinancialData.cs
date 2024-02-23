using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class FinancialData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required Amount Price { get; set; }
    public required Amount ValueToSetAside { get; set; }
    public required Amount OtherPayments { get; set; }
    public required Amount CompensationFundSubsidy { get; set; }
    public required Amount MinistryOfHousingSubsidy { get; set; }
    public required Amount LoanValue { get; set; }
    public required string LoanEntity { get; set; }
    public required Amount Debt { get; set; }
}

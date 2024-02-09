using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class SaleFinancialData : Entity
{
    protected SaleFinancialData() { }

    public SaleFinancialData(Amount price, Amount valueToSetAside, Amount otherPayments, Amount compensationFundSubsidy, Amount ministryOfHousingSubsidy, Amount loanValue, string loanEntity, Amount debt)
    {
        Price = price;
        ValueToSetAside = valueToSetAside;
        OtherPayments = otherPayments;
        CompensationFundSubsidy = compensationFundSubsidy;
        MinistryOfHousingSubsidy = ministryOfHousingSubsidy;
        LoanValue = loanValue;
        LoanEntity = loanEntity;
        Debt = debt;
    }

    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public Amount Price { get; set; }
    public Amount ValueToSetAside { get; set; }
    public Amount OtherPayments { get; set; }
    public Amount CompensationFundSubsidy { get; set; }
    public Amount MinistryOfHousingSubsidy { get; set; }
    public Amount LoanValue { get; set; }
    public string LoanEntity { get; set; }
    public Amount Debt { get; set; }
}

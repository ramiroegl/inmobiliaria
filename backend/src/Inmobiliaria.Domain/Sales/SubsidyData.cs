using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class SubsidyData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool DialedMinistryCollection { get; set; }
    public required bool MinistryPayment { get; set; }
    public required bool CompensationBoxSubsidyFiled { get; set; }
    public required bool CompensationCashPayment { get; set; }
    public required DateOnly LoanDisbursementDate { get; set; }
}

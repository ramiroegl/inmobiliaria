using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class DeedData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required bool ConstructionCompanySignature { get; set; }
    public required bool CustomerSignature { get; set; }
    public required bool PropertySellerSignature { get; set; }
    public required bool BankSignature { get; set; }
    public required bool CopiesAndSettlement { get; set; }
    public required DateOnly EntryDateIntoPublicInstruments { get; set; }
}

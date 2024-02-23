using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class DeedData : Entity
{
    public required bool ConstructionCompanySignature { get; set; }
    public required bool CustomerSignature { get; set; }
    public required bool PropertySellerSignature { get; set; }
    public required bool CopiesAndSettlement { get; set; }
    public required DateOnly EntryDateIntoPublicInstruments { get; set; }
}

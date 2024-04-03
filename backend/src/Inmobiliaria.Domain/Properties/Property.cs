using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Properties;

public class Property : Entity
{
    private string _tuition;
    private Amount _price;
    private Coordinates _coordinates;
    private string _block;
    private string _lot;

    public required string Tuition { get => _tuition; [MemberNotNull(nameof(_tuition))] set => _tuition = value.NotNullOrWhiteSpace(); }
    public required Amount Price { get => _price; [MemberNotNull(nameof(_price))] set => _price = value.NotNull(); }
    public required Coordinates Coordinates { get => _coordinates; [MemberNotNull(nameof(_coordinates))] set => _coordinates = value.NotNull(); }
    public required string Block { get => _block; [MemberNotNull(nameof(_block))] set => _block = value.NotNull(); }
    public required string Lot { get => _lot; [MemberNotNull(nameof(_lot))] set => _lot = value.NotNull(); }
    public ICollection<SaleProperty>? Sales { get; private init; }
}

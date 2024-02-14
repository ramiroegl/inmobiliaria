using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class SaleProperty : Entity
{
    private string _tuition;
    private Amount _price;
    private Coordinates _coordinates;
    private string _block;
    private string _lot;

    protected SaleProperty() { }

    public SaleProperty(Property property)
    {
        PropertyId = property.Id;
        Property = property;
        Tuition = property.Tuition;
        Price = property.Price;
        Coordinates = property.Coordinates;
        Block = property.Block;
        Lot = property.Lot;
    }

    public Guid PropertyId { get; private init; }
    public Property? Property { get; private init; }
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public string Tuition { get => _tuition; [MemberNotNull(nameof(_tuition))] set => _tuition = value.NotNullOrWhiteSpace(); }
    public Amount Price { get => _price; [MemberNotNull(nameof(_price))] set => _price = value.NotNull(); }
    public Coordinates Coordinates { get => _coordinates; [MemberNotNull(nameof(_coordinates))] set => _coordinates = value.NotNull(); }
    public string Block { get => _block; [MemberNotNull(nameof(_block))] set => _block = value.NotNullOrEmpty(); }
    public string Lot { get => _lot; [MemberNotNull(nameof(_lot))] set => _lot = value.NotNullOrEmpty(); }
}

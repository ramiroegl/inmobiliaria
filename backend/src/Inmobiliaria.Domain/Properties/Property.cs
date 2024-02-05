using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Properties;

public class Property : Entity
{
    private Amount _price;
    private Coordinates _coordinates;
    private string _tuition;
    private string _block;
    private string _lot;

    protected Property() { }

    public Property(Amount price, Coordinates coordinates, string tuition, string block, string lot)
    {
        Price = price;
        Coordinates = coordinates;
        Tuition = tuition;
        Block = block;
        Lot = lot;
    }

    public Amount Price
    {
        get => _price;
        [MemberNotNull(nameof(_price))]
        set => _price = value.NotNull();
    }

    public Coordinates Coordinates
    {
        get => _coordinates;
        [MemberNotNull(nameof(_coordinates))]
        set => _coordinates = value.NotNull();
    }

    public string Tuition
    {
        get => _tuition;
        [MemberNotNull(nameof(_tuition))]
        set => _tuition = value.NotNullOrWhiteSpace();
    }

    public string Block
    {
        get => _block;
        [MemberNotNull(nameof(_block))]
        set => _block = value.NotNullOrEmpty();
    }

    public string Lot
    {
        get => _lot;
        [MemberNotNull(nameof(_lot))]
        set => _lot = value.NotNullOrEmpty();
    }

    public ICollection<Sale> Sales { get; private init; }
}

using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Properties;

public class Property : Entity
{
    protected Property() { }

    public Property(Amount value, Coordinates coordinates, string tuition, string block, string lot)
    {
        Value = value;
        Coordinates = coordinates;
        Tuition = tuition;
        Block = block;
        Lot = lot;
    }

    public Amount Value { get; set; }
    public Coordinates Coordinates { get; set; }
    public string Tuition { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
}

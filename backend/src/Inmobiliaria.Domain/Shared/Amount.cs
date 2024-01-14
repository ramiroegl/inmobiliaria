namespace Inmobiliaria.Domain.Shared;

public record Amount
{
    private decimal _value;

    public Amount(decimal value)
    {
        Value = value;
    }

    public decimal Value
    {
        get => _value;
        init => _value = value.GreaterOrEqualTo(decimal.Zero);
    }

    public static implicit operator decimal(Amount amount) => amount.Value;
    public static implicit operator Amount(decimal value) => new(value);
}

using Inmobiliaria.Domain.Shared;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inmobiliaria.Infrastructure.Shared;

public class AmountConverter()
    : ValueConverter<Amount, decimal>(amount => amount.Value, value => new Amount(value));

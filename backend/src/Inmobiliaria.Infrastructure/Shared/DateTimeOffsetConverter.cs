using Inmobiliaria.Domain.Shared;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inmobiliaria.Infrastructure.Shared;

public class DateTimeOffsetConverter(ITimeProvider timeProvider)
    : ValueConverter<DateTimeOffset, DateTimeOffset>(app => timeProvider.ToUtc(app), db => timeProvider.ToLocalZone(db));

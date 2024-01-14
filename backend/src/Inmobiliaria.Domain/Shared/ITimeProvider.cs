namespace Inmobiliaria.Domain.Shared;

public interface ITimeProvider
{
    DateTimeOffset Now { get; }
    DateTimeOffset UtcNow { get; }
    DateTimeOffset ToLocalZone(DateTimeOffset dateTimeOffset);
    DateTimeOffset ToUtc(DateTimeOffset dateTimeOffset);
}

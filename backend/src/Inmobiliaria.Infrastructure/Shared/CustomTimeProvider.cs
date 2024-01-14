using Inmobiliaria.Domain.Shared;
using TimeZoneConverter;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomTimeProvider : ITimeProvider
{
    private readonly string _timeZoneId;
    private readonly TimeZoneInfo _timeZoneInfo;

    public CustomTimeProvider(string timeZoneId)
    {
        _timeZoneId = timeZoneId;
        _timeZoneInfo = TZConvert.GetTimeZoneInfo(_timeZoneId);
    }

    public DateTimeOffset Now => ToLocalZone(UtcNow);

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public TimeZoneInfo TimeZone => _timeZoneInfo;

    public TimeSpan TimeZoneOffset => _timeZoneInfo.BaseUtcOffset;

    public DateTimeOffset ToLocalZone(DateTimeOffset dateTime) => TimeZoneInfo.ConvertTime(dateTime, TimeZone);

    public DateTimeOffset ToUtc(DateTimeOffset dateTime) => dateTime.UtcDateTime;
}

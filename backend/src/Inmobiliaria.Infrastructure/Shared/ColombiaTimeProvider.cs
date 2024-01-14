using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Infrastructure.Shared;

public class ColombiaTimeProvider : CustomTimeProvider, ITimeProvider
{
    private const string COLOMBIA_TIME_ZONE = "America/Bogota";
    public ColombiaTimeProvider() : base(COLOMBIA_TIME_ZONE) { }
}

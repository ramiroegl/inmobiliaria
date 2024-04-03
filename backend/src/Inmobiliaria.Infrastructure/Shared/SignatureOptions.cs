namespace Inmobiliaria.Infrastructure.Shared;

public record SignatureOptions
{
    public required string SymmetricKey { get; init; }
    public required TimeSpan SignatureLifetime { get; init; }
}

namespace Inmobiliaria.Api.Models;

public record ResetPasswordModel
{
    public required string NewPassword { get; init; }
}

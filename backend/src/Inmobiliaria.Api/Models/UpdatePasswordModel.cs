namespace Inmobiliaria.Api.Models;

public record UpdatePasswordModel
{
    public required string Password { get; init; }
    public required string NewPassword { get; init; }
}

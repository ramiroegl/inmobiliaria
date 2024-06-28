using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Users;

public class User : Entity
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
}

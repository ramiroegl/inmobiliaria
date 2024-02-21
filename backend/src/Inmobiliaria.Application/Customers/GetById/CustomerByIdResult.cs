using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Application.Customers.GetById;

public record CustomerByIdResult
{
    public required Guid Id { get; init; }
    public required string Names { get; init; }
    public required string LastNames { get; init; }
    public required string Email { get; init; }
    public required Identity Identity { get; init; }
    public required decimal Salary { get; init; }
    public required CivilStatus CivilStatus { get; init; }
    public required string PhoneNumber { get; init; }
}

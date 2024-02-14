using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Shared;
using MediatR;

namespace Inmobiliaria.Application.Customers.Create;

public record CreateCustomerCommand : IRequest<CreatedCustomerResult>
{
    public required string Email { get; init; }
    public required string Names { get; init; }
    public required string LastNames { get; init; }
    public required Identity Identity { get; init; }
    public required CivilStatus CivilStatus { get; init; }
    public required decimal Salary { get; init; }
    public required string PhoneNumber { get; init; }
}

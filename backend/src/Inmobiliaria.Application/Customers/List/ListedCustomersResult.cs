using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;

namespace Inmobiliaria.Application.Customers.List;

public record ListedCustomersResult : PaginatedResult<ListedCustomersResult.ListedCustomerDto>
{
    public record ListedCustomerDto
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
}

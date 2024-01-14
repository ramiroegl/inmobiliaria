using Inmobiliaria.Domain.Customers;

namespace Inmobiliaria.Application.Customers.Create;

public record CreatedCustomerResult(Guid Id, string Names, string LastNames, Identity Identity, string PhoneNumber);

using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomMapper : IMapper
{
    public CreatedCustomerResult Map(Customer customer) =>
        new(customer.Id, customer.Names, customer.LastNames, customer.Identity, customer.PhoneNumber);

    public Customer Map(CreateCustomerCommand customer) =>
        new(customer.Email, customer.Names, customer.LastNames, customer.Identity, customer.CivilStatus, customer.Salary, customer.PhoneNumber);
}

using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Domain.Customers;

namespace Inmobiliaria.Application.Shared;

public interface IMapper
{
    CreatedCustomerResult Map(Customer customer);
    Customer Map(CreateCustomerCommand customer);
}

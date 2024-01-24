using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;

namespace Inmobiliaria.Application.Shared;

public interface IMapper
{
    Customer ToCustomer(CreateCustomerCommand command);
    CreatedCustomerResult ToCreatedCustomer(Customer customer);

    CustomerByIdResult ToCustomerById(Customer customer);

    UpdatedCustomerResult ToUpdatedCustomer(Customer customer);

    DeletedCustomerResult ToDeletedCustomer(Customer customer);

    IEnumerable<ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers);

    Property ToProperty(CreatePropertyCommand command);
    CreatedPropertyResult ToCreatedProperty(Property property);
}

using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomMapper : IMapper
{
    public Customer ToCustomer(CreateCustomerCommand customer) =>
        new(customer.Email, customer.Names, customer.LastNames, customer.Identity, customer.CivilStatus, customer.Salary, customer.PhoneNumber);

    public CreatedCustomerResult ToCreatedCustomer(Customer customer) =>
        new(customer.Id);

    public CustomerByIdResult ToCustomerById(Customer customer) =>
        new()
        {
            Email = customer.Email,
            Id = customer.Id,
            Identity = customer.Identity,
            LastNames = customer.LastNames,
            Names = customer.Names,
            CivilStatus = customer.CivilStatus,
            PhoneNumber = customer.PhoneNumber,
            Salary = customer.Salary
        };

    public UpdatedCustomerResult ToUpdatedCustomer(Customer customer) =>
        new(customer.Id);

    public DeletedCustomerResult ToDeletedCustomer(Customer customer)
        => new();

    public IEnumerable<ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers) =>
        customers.Select(customer => new ListedCustomerDto
        {
            Email = customer.Email,
            Id = customer.Id,
            Identity = customer.Identity,
            LastNames = customer.LastNames,
            Names = customer.Names,
            CivilStatus = customer.CivilStatus,
            PhoneNumber = customer.PhoneNumber,
            Salary = customer.Salary
        });

    public Property ToProperty(CreatePropertyCommand command) =>
        new(command.Value, command.Coordinates, command.Tuition, command.Lot, command.Lot);

    public CreatedPropertyResult ToCreatedProperty(Property property) =>
        new(property.Id);
}

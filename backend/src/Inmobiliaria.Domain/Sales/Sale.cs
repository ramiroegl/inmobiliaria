using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class Sale : Entity
{
    private Guid _customerId;
    private Customer? _customer;
    private Guid _propertyId;
    private Property? _property;

    protected Sale() { }

    public Sale(Customer customer, Property property)
    {
        CustomerId = customer.Id;
        Customer = customer;
        PropertyId = property.Id;
        Property = property;
        CustomerData = customer;
        PropertyData = property;
    }

    public Guid CustomerId
    {
        get => _customerId;
        private init => _customerId = value;
    }

    public Customer? Customer
    {
        get => _customer;
        private init => _customer = value;
    }

    public Guid PropertyId
    {
        get => _propertyId;
        private init => _propertyId = value;
    }

    public Property? Property
    {
        get => _property;
        private init => _property = value;
    }

    public Customer CustomerData { get; private init; }
    public Property PropertyData { get; private init; }
}

using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class Sale : Entity
{
    protected Sale() { }

    public Sale(Customer customer, Property property)
    {
        Customer = new SaleCustomer(customer);
        Property = new SaleProperty(property);
    }

    public SaleCustomer Customer { get; private init; }
    public SaleProperty Property { get; private init; }
    public required FinancialData FinancialData { get; init; }
    public required DocumentaryData DocumentaryData { get; init; }
    public required AppraisalData AppraisalData { get; init; }
    public required DeedData DeedData { get; init; }
}

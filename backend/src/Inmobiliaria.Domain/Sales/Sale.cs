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

    public SaleCustomer Customer { get; init; }
    public SaleProperty Property { get; init; }
    public required FinancialData FinancialData { get; init; }
    public required DocumentaryData DocumentaryData { get; init; }
    public required AppraisalData AppraisalData { get; init; }
    public required DeedData DeedData { get; init; }
    public required DeedCostsData DeedCostsData { get; init; }
    public required DeliveryData DeliveryData { get; init; }
    public required SubsidyData SubsidyData { get; init; }
    public required ServicesData ServicesData { get; init; }
    public required VisitData VisitData { get; init; }
    public bool Deleted { get; set; }
}

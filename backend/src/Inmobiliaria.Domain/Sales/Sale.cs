using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class Sale : Entity
{
    protected Sale() { }

    public Sale(Customer customer, Property property, SaleFinancialData financialData, SaleDocumentaryData documentaryData)
    {
        Customer = new SaleCustomer(customer);
        Property = new SaleProperty(property);
        FinancialData = financialData;
        DocumentaryData = documentaryData;
    }

    public SaleCustomer Customer { get; private init; }
    public SaleProperty Property { get; private init; }
    public SaleFinancialData FinancialData { get; private init; }
    public SaleDocumentaryData DocumentaryData { get; private init; }
}

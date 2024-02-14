using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.List;
using Inmobiliaria.Application.Shared.DTOs;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;

namespace Inmobiliaria.Application.Shared;

public interface IMapper
{
    Identity ToIdentity(IdentityDto dto);

    Customer ToCustomer(CreateCustomerCommand command);

    CreatedCustomerResult ToCreatedCustomer(Customer customer);

    CustomerByIdResult ToCustomerById(Customer customer);

    UpdatedCustomerResult ToUpdatedCustomer(Customer customer);

    DeletedCustomerResult ToDeletedCustomer(Customer customer);

    IEnumerable<ListedCustomersResult.ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers);

    Property ToProperty(CreatePropertyCommand command);

    CreatedPropertyResult ToCreatedProperty(Property property);

    Customer ToCustomer(CreateSaleCommand.CreateSaleCustomerDto dto);

    Property ToProperty(CreateSaleCommand.CreateSalePropertyDto dto);

    SaleFinancialData ToFinancialData(CreateSaleCommand.CreateSaleFinancialDataDto dto);

    SaleDocumentaryData ToDocumentaryData(CreateSaleCommand.CreateSaleDocumentaryDataDto dto);

    IEnumerable<ListedSalesResult.ListedSaleDto> ToListedSales(IEnumerable<Sale> sales);
}

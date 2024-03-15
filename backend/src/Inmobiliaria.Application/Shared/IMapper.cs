using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.List;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;

namespace Inmobiliaria.Application.Shared;

public interface IMapper
{
    // Create Customer
    Customer ToCustomer(CreateCustomerCommand command);
    CreatedCustomerResult ToCreatedCustomer(Customer customer);

    // Get Customer
    CustomerByIdResult ToCustomerById(Customer customer);

    // Update Customer
    UpdatedCustomerResult ToUpdatedCustomer(Customer customer);

    // Delete Customer
    DeletedCustomerResult ToDeletedCustomer(Customer customer);

    // List Customers
    IEnumerable<ListedCustomersResult.ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers);

    // Create Property
    Property ToProperty(CreatePropertyCommand command);
    CreatedPropertyResult ToCreatedProperty(Property property);

    // Create Sale
    Customer ToCustomer(CreateSaleCommand.CreateSaleCustomerDto dto);
    Property ToProperty(CreateSaleCommand.CreateSalePropertyDto dto);
    FinancialData ToFinancialData(CreateSaleCommand.CreateFinancialDataDto dto);
    DocumentaryData ToDocumentaryData(CreateSaleCommand.CreateDocumentaryDataDto dto);
    AppraisalData ToAppraisalData(CreateSaleCommand.CreateAppraisalDataDto dto);
    DeedData ToDeedData(CreateSaleCommand.CreateDeedDataDto dto);
    DeedCostsData ToDeedCostsData(CreateSaleCommand.CreateDeedCostsDataDto dto);
    DeliveryData ToDeliveryData(CreateSaleCommand.CreateDeliveryDataDto dto);
    SubsidyData ToSubsidyData(CreateSaleCommand.CreateSubsidyDataDto dto);
    ServicesData ToServicesData(CreateSaleCommand.CreateServicesDataDto dto);
    VisitData ToVisitData(CreateSaleCommand.CreateVisitDataDto dto);

    // Update Sale
    Customer ToCustomer(UpdateSaleCommand.UpdateSaleCustomerDto dto);
    Property ToProperty(UpdateSaleCommand.UpdateSalePropertyDto dto);

    // List Sales
    IEnumerable<ListedSalesResult.ListedSaleDto> ToListedSales(IEnumerable<Sale> sales);
}

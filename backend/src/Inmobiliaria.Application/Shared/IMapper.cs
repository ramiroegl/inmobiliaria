using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.GetByIdentity;
using Inmobiliaria.Application.Customers.GetByTuition;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Properties.Delete;
using Inmobiliaria.Application.Properties.List;
using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.Shared;
using Inmobiliaria.Application.Users.Delete;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Users;

namespace Inmobiliaria.Application.Shared;

public interface IMapper
{
    // Create Customer
    Customer ToCustomer(CreateCustomerCommand command);
    CreatedCustomerResult ToCreatedCustomer(Customer customer);

    // Get Customer
    CustomerByIdResult ToCustomerById(Customer customer);
    CustomerByIdentityResult ToCustomerByIdentity(Customer customer);

    // Update Customer
    UpdatedCustomerResult ToUpdatedCustomer(Customer customer);

    // Delete Customer
    DeletedCustomerResult ToDeletedCustomer(Customer customer);

    // List Customers
    IEnumerable<ListedCustomersResult.ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers);

    // Create Property
    Property ToProperty(CreatePropertyCommand command);
    CreatedPropertyResult ToCreatedProperty(Property property);
    PropertyByTuitionResult ToPropertyByTuition(Property property);

    // List Properties
    IEnumerable<ListedPropertiesResult.ListedPropertyDto> ToListedProperties(IEnumerable<Property> properties);

    // Delete Property
    DeletedPropertyResult ToDeletedProperty(Property property);

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
    IEnumerable<SaleDto> ToListedSales(IEnumerable<Sale> sales);

    // Get Sale
    SaleDto ToSale(Sale sale);

    // List Users
    IEnumerable<UserDto> ToListedUsers(IEnumerable<User> sales);

    // Delete Customer
    DeletedUserResult ToDeletedUser(User user);
}

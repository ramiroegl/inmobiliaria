using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.List;
using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomMapper : IMapper
{
    public Customer ToCustomer(CreateCustomerCommand customer) =>
        new(customer.Identity, customer.Email, customer.Names, customer.LastNames, customer.CivilStatus, customer.Salary, customer.PhoneNumber);

    public CreatedCustomerResult ToCreatedCustomer(Customer customer) => new(customer.Id);

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

    public UpdatedCustomerResult ToUpdatedCustomer(Customer customer) => new(customer.Id);

    public DeletedCustomerResult ToDeletedCustomer(Customer customer) => new();

    public IEnumerable<ListedCustomersResult.ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers) =>
        customers.Select(customer => new ListedCustomersResult.ListedCustomerDto
        {
            Id = customer.Id,
            Email = customer.Email,
            Identity = customer.Identity,
            LastNames = customer.LastNames,
            Names = customer.Names,
            CivilStatus = customer.CivilStatus,
            PhoneNumber = customer.PhoneNumber,
            Salary = customer.Salary
        });

    public Property ToProperty(CreatePropertyCommand command) =>
        new(command.Tuition, command.Price, command.Coordinates, command.Block, command.Lot);

    public CreatedPropertyResult ToCreatedProperty(Property property) => new(property.Id);

    public Customer ToCustomer(CreateSaleCommand.CustomerDto dto) =>
        new(dto.Identity, dto.Email, dto.Names, dto.LastNames, dto.CivilStatus, dto.Salary, dto.PhoneNumber);

    public Property ToProperty(CreateSaleCommand.PropertyDto dto) =>
        new(dto.Tuition, dto.Price, dto.Coordinates, dto.Block, dto.Lot);

    public SaleFinancialData ToFinancialData(CreateSaleCommand.FinancialDataDto dto) =>
        new(dto.Price, dto.ValueToSetAside, dto.OtherPayments, dto.CompensationFundSubsidy, dto.MinistryOfHousingSubsidy, dto.LoanValue, dto.LoanEntity, dto.Debt);

    public IEnumerable<ListedSalesResult.ListedSaleDto> ToListedSales(IEnumerable<Sale> sales) =>
        sales.Select(sale => new ListedSalesResult.ListedSaleDto
        {
            Id = sale.Id,
            Customer = new ListedSalesResult.ListedSaleDto.ListedSaleCustomerDto
            {
                CustomerId = sale.Customer.CustomerId,
                Email = sale.Customer.Email,
                CivilStatus = sale.Customer.CivilStatus,
                Identity = sale.Customer.Identity,
                LastNames = sale.Customer.LastNames,
                Names = sale.Customer.Names,
                PhoneNumber = sale.Customer.PhoneNumber,
                Salary = sale.Customer.Salary
            },
            Property = new ListedSalesResult.ListedSaleDto.ListedSalePropertyDto
            {
                Block = sale.Property.Block,
                Coordinates = sale.Property.Coordinates,
                Lot = sale.Property.Lot,
                Price = sale.Property.Price,
                PropertyId = sale.Property.PropertyId,
                Tuition = sale.Property.Tuition
            },
            FinancialData = new ListedSalesResult.ListedSaleDto.ListedSaleFinancialDataDto
            {
                CompensationFundSubsidy = sale.FinancialData.CompensationFundSubsidy,
                Debt = sale.FinancialData.Debt,
                LoanEntity = sale.FinancialData.LoanEntity,
                LoanValue = sale.FinancialData.LoanValue,
                MinistryOfHousingSubsidy = sale.FinancialData.MinistryOfHousingSubsidy,
                OtherPayments = sale.FinancialData.OtherPayments,
                Price = sale.FinancialData.Price,
                ValueToSetAside = sale.FinancialData.ValueToSetAside
            },
            CreatedOn = sale.CreatedOn,
            UpdatedOn = sale.UpdatedOn
        });
}

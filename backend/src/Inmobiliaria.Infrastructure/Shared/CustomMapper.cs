using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Shared;
using Inmobiliaria.Application.Shared.DTOs;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomMapper : IMapper
{
    public Identity ToIdentity(IdentityDto dto) =>
        new(dto.Type, dto.Value, DateOnly.FromDateTime(dto.DateOfIssue.LocalDateTime));

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

    public Customer ToCustomer(CreateSaleCommand.CreateSaleCustomerDto dto) =>
        new(ToIdentity(dto.Identity), dto.Email, dto.Names, dto.LastNames, dto.CivilStatus, dto.Salary, dto.PhoneNumber);

    public Property ToProperty(CreateSaleCommand.CreateSalePropertyDto dto) =>
        new(dto.Tuition, dto.Price, dto.Coordinates, dto.Block, dto.Lot);

    public FinancialData ToFinancialData(CreateSaleCommand.CreateFinancialDataDto dto) =>
        new()
        {
            Price = dto.Price,
            ValueToSetAside = dto.ValueToSetAside,
            OtherPayments = dto.OtherPayments,
            CompensationFundSubsidy = dto.CompensationFundSubsidy,
            MinistryOfHousingSubsidy = dto.MinistryOfHousingSubsidy,
            LoanValue = dto.LoanValue,
            LoanEntity = dto.LoanEntity,
            Debt = dto.Debt
        };

    public DocumentaryData ToDocumentaryData(CreateSaleCommand.CreateDocumentaryDataDto dto) =>
        new()
        {
            IdentificationDocument = dto.Identification,
            SignedPledge = dto.SignedPledge,
            CreditApprovalLetter = dto.CreditApprovalLetter,
            ApprovalLetterNumber = dto.ApprovalLetterNumber,
            CompensationFundRecordNumber = dto.CompensationFundRecordNumber,
            MinistrySubsidyResolution = dto.MinistrySubsidyResolution,
            DeliveryDocument = dto.Delivery
        };

    public AppraisalData ToAppraisalData(CreateSaleCommand.CreateAppraisalDataDto dto) =>
        new()
        {
            FamilyCodeInMinistryOfHousing = dto.FamilyCodeInMinistryOfHousing,
            IssuanceByTheBankOfALetterOfRatification = dto.IssuanceByTheBankOfALetterOfRatification,
            Payment = dto.Payment,
            Report = dto.Report,
            RequestSubmissionOfDocuments = dto.RequestSubmissionOfDocuments,
            SendingDocumentsForTitleStudy = dto.SendingDocumentsForTitleStudy,
            TitleStudyPayment = dto.TitleStudyPayment,
            Visit = dto.Visit
        };

    public DeedData ToDeedData(CreateSaleCommand.CreateDeedDataDto dto) =>
        new()
        {
            ConstructionCompanySignature = dto.ConstructionCompanySignature,
            CopiesAndSettlement = dto.CopiesAndSettlement,
            CustomerSignature = dto.CustomerSignature,
            EntryDateIntoPublicInstruments = DateOnly.FromDateTime(dto.EntryDateIntoPublicInstruments.LocalDateTime),
            PropertySellerSignature = dto.PropertySellerSignature
        };
}

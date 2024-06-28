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
using Inmobiliaria.Application.Shared;
using Inmobiliaria.Application.Users.Delete;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Users;

namespace Inmobiliaria.Infrastructure.Shared;

public class CustomMapper : IMapper
{
    public Customer ToCustomer(CreateCustomerCommand dto) => new()
    {
        CivilStatus = dto.CivilStatus,
        Email = dto.Email,
        Identity = dto.Identity,
        LastNames = dto.LastNames,
        Names = dto.Names,
        PhoneNumber = dto.PhoneNumber,
        Salary = dto.Salary
    };

    public CreatedCustomerResult ToCreatedCustomer(Customer customer) => new(customer.Id);

    public CustomerByIdResult ToCustomerById(Customer customer) => new()
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

    public CustomerByIdentityResult ToCustomerByIdentity(Customer customer) => new()
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

    public IEnumerable<ListedCustomersResult.ListedCustomerDto> ToListedCustomers(IEnumerable<Customer> customers) => customers
        .Select(customer => new ListedCustomersResult.ListedCustomerDto
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

    public Property ToProperty(CreatePropertyCommand command) => new()
    {
        Block = command.Block,
        Coordinates = command.Coordinates,
        Lot = command.Lot,
        Price = command.Price,
        Tuition = command.Tuition
    };

    public CreatedPropertyResult ToCreatedProperty(Property property) => new(property.Id);

    public IEnumerable<ListedPropertiesResult.ListedPropertyDto> ToListedProperties(IEnumerable<Property> properties) => properties
        .Select(property => new ListedPropertiesResult.ListedPropertyDto
        {
            Id = property.Id,
            Block = property.Block,
            Coordinates = property.Coordinates,
            Lot = property.Lot,
            Price = property.Price,
            Tuition = property.Tuition
        });

    public DeletedPropertyResult ToDeletedProperty(Property _) => new();

    public PropertyByTuitionResult ToPropertyByTuition(Property property) => new()
    {
        Id = property.Id,
        Block = property.Block,
        Coordinates = property.Coordinates,
        Lot = property.Lot,
        Price = property.Price,
        Tuition = property.Tuition
    };

    public Customer ToCustomer(CreateSaleCommand.CreateSaleCustomerDto dto) => new()
    {
        CivilStatus = dto.CivilStatus,
        Email = dto.Email,
        Identity = dto.Identity,
        LastNames = dto.LastNames,
        Names = dto.Names,
        PhoneNumber = dto.PhoneNumber,
        Salary = dto.Salary
    };

    public Property ToProperty(CreateSaleCommand.CreateSalePropertyDto dto) => new()
    {
        Block = dto.Block,
        Coordinates = dto.Coordinates,
        Lot = dto.Lot,
        Price = dto.Price,
        Tuition = dto.Tuition
    };

    public FinancialData ToFinancialData(CreateSaleCommand.CreateFinancialDataDto dto) => new()
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

    public DocumentaryData ToDocumentaryData(CreateSaleCommand.CreateDocumentaryDataDto dto) => new()
    {
        IdentificationDocument = dto.IdentificationDocument,
        SignedPledge = dto.SignedPledge,
        CreditApprovalLetter = dto.CreditApprovalLetter,
        ApprovalLetterNumber = dto.ApprovalLetterNumber,
        CompensationFundRecordNumber = dto.CompensationFundRecordNumber,
        MinistrySubsidyResolution = dto.MinistrySubsidyResolution,
        DeliveryDocument = dto.DeliveryDocument
    };

    public AppraisalData ToAppraisalData(CreateSaleCommand.CreateAppraisalDataDto dto) => new()
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

    public DeedData ToDeedData(CreateSaleCommand.CreateDeedDataDto dto) => new()
    {
        ConstructionCompanySignature = dto.ConstructionCompanySignature,
        CopiesAndSettlement = dto.CopiesAndSettlement,
        PropertySellerSignature = dto.PropertySellerSignature,
        BankSignature = dto.BankSignature,
        CustomerSignature = dto.CustomerSignature,
        EntryDateIntoPublicInstruments = DateOnly.FromDateTime(dto.EntryDateIntoPublicInstruments.LocalDateTime),
    };

    public DeedCostsData ToDeedCostsData(CreateSaleCommand.CreateDeedCostsDataDto dto) => new()
    {
        DeedCosts = dto.DeedCosts,
        DeedDebt = dto.DeedDebt,
        GovernmentPayment = dto.GovernmentPayment,
        NotaryPayment = dto.NotaryPayment,
        PropertyPayment = dto.PropertyPayment,
        PublicInstrumentsPayment = dto.PublicInstrumentsPayment
    };

    public DeliveryData ToDeliveryData(CreateSaleCommand.CreateDeliveryDataDto dto) => new()
    {
        DeedSentToLawyer = dto.DeedSentToLawyer,
        DisbursementInstruction = dto.DisbursementInstruction,
        PeaceAndSafetyPropertySeller = dto.PeaceAndSafetyPropertySeller,
        ScannedCTL = dto.ScannedCTL,
        ScannedDeed = dto.ScannedDeed,
        ScannedDeliveryCertificate = dto.ScannedDeliveryCertificate,
        ScannedTaxAndRegistrationSlip = dto.ScannedTaxAndRegistrationSlip
    };

    public SubsidyData ToSubsidyData(CreateSaleCommand.CreateSubsidyDataDto dto) => new()
    {
        CompensationBoxSubsidyFiled = dto.CompensationBoxSubsidyFiled,
        CompensationCashPayment = dto.CompensationCashPayment,
        DialedMinistryCollection = dto.DialedMinistryCollection,
        LoanDisbursementDate = DateOnly.FromDateTime(dto.LoanDisbursementDate.LocalDateTime),
        MinistryPayment = dto.MinistryPayment
    };

    public ServicesData ToServicesData(CreateSaleCommand.CreateServicesDataDto dto) => new()
    {
        ElectricMeterValue = dto.ElectricMeterValue,
        InstalledElectricMeter = dto.InstalledElectricMeter,
        InstalledWaterMeter = dto.InstalledWaterMeter
    };

    public VisitData ToVisitData(CreateSaleCommand.CreateVisitDataDto dto) => new()
    {
        Visit = dto.Visit,
        Certified = dto.Certified,
        SentAfiniaDocuments = dto.SentAfiniaDocuments
    };

    public Customer ToCustomer(UpdateSaleCommand.UpdateSaleCustomerDto dto) => new()
    {
        CivilStatus = dto.CivilStatus,
        Email = dto.Email,
        Identity = dto.Identity,
        LastNames = dto.LastNames,
        Names = dto.Names,
        PhoneNumber = dto.PhoneNumber,
        Salary = dto.Salary
    };

    public Property ToProperty(UpdateSaleCommand.UpdateSalePropertyDto dto) => new()
    {
        Block = dto.Block,
        Coordinates = dto.Coordinates,
        Lot = dto.Lot,
        Price = dto.Price,
        Tuition = dto.Tuition
    };

    public IEnumerable<SaleDto> ToListedSales(IEnumerable<Sale> sales) => sales.Select(ToSale);

    public SaleDto ToSale(Sale sale) => new()
    {
        Id = sale.Id,
        Customer = new SaleDto.ListedSaleCustomerDto
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
        Property = new SaleDto.ListedSalePropertyDto
        {
            Block = sale.Property.Block,
            Coordinates = sale.Property.Coordinates,
            Lot = sale.Property.Lot,
            Price = sale.Property.Price,
            PropertyId = sale.Property.PropertyId,
            Tuition = sale.Property.Tuition
        },
        FinancialData = new SaleDto.ListedSaleFinancialDataDto
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
        DocumentaryData = new SaleDto.ListedSaleDocumentaryDataDto
        {
            DeliveryDocument = sale.DocumentaryData.DeliveryDocument,
            CompensationFundRecordNumber = sale.DocumentaryData.CompensationFundRecordNumber,
            ApprovalLetterNumber = sale.DocumentaryData.ApprovalLetterNumber,
            IdentificationDocument = sale.DocumentaryData.IdentificationDocument,
            SignedPledge = sale.DocumentaryData.SignedPledge,
            CreditApprovalLetter = sale.DocumentaryData.CreditApprovalLetter,
            MinistrySubsidyResolution = sale.DocumentaryData.MinistrySubsidyResolution
        },
        AppraisalData = new SaleDto.ListedSaleAppraisalDataDto
        {
            FamilyCodeInMinistryOfHousing = sale.AppraisalData.FamilyCodeInMinistryOfHousing,
            IssuanceByTheBankOfALetterOfRatification = sale.AppraisalData.IssuanceByTheBankOfALetterOfRatification,
            Payment = sale.AppraisalData.Payment,
            Report = sale.AppraisalData.Report,
            RequestSubmissionOfDocuments = sale.AppraisalData.RequestSubmissionOfDocuments,
            SendingDocumentsForTitleStudy = sale.AppraisalData.SendingDocumentsForTitleStudy,
            TitleStudyPayment = sale.AppraisalData.TitleStudyPayment,
            Visit = sale.AppraisalData.Visit
        },
        DeedData = new SaleDto.ListedSaleDeedDataDto
        {
            ConstructionCompanySignature = sale.DeedData.ConstructionCompanySignature,
            CopiesAndSettlement = sale.DeedData.CopiesAndSettlement,
            CustomerSignature = sale.DeedData.CustomerSignature,
            EntryDateIntoPublicInstruments = sale.DeedData.EntryDateIntoPublicInstruments,
            PropertySellerSignature = sale.DeedData.PropertySellerSignature,
            BankSignature = sale.DeedData.BankSignature,
        },
        DeedCostsData = new SaleDto.ListedDeedCostsDataDto
        {
            DeedCosts = sale.DeedCostsData.DeedCosts,
            DeedDebt = sale.DeedCostsData.DeedDebt,
            GovernmentPayment = sale.DeedCostsData.GovernmentPayment,
            NotaryPayment = sale.DeedCostsData.NotaryPayment,
            PropertyPayment = sale.DeedCostsData.PropertyPayment,
            PublicInstrumentsPayment = sale.DeedCostsData.PublicInstrumentsPayment
        },
        DeliveryData = new SaleDto.ListedDeliveryDataDto
        {
            DeedSentToLawyer = sale.DeliveryData.DeedSentToLawyer,
            DisbursementInstruction = sale.DeliveryData.DisbursementInstruction,
            PeaceAndSafetyPropertySeller = sale.DeliveryData.PeaceAndSafetyPropertySeller,
            ScannedCTL = sale.DeliveryData.ScannedCTL,
            ScannedDeed = sale.DeliveryData.ScannedDeed,
            ScannedDeliveryCertificate = sale.DeliveryData.ScannedDeliveryCertificate,
            ScannedTaxAndRegistrationSlip = sale.DeliveryData.ScannedTaxAndRegistrationSlip,
        },
        SubsidyData = new SaleDto.ListedSubsidyDataDto
        {
            CompensationBoxSubsidyFiled = sale.SubsidyData.CompensationBoxSubsidyFiled,
            CompensationCashPayment = sale.SubsidyData.CompensationCashPayment,
            DialedMinistryCollection = sale.SubsidyData.DialedMinistryCollection,
            LoanDisbursementDate = sale.SubsidyData.LoanDisbursementDate,
            MinistryPayment = sale.SubsidyData.MinistryPayment
        },
        ServicesData = new SaleDto.ListedServicesDataDto
        {
            ElectricMeterValue = sale.ServicesData.ElectricMeterValue,
            InstalledElectricMeter = sale.ServicesData.InstalledElectricMeter,
            InstalledWaterMeter = sale.ServicesData.InstalledWaterMeter
        },
        VisitData = new SaleDto.ListedVisitDataDto
        {
            Certified = sale.VisitData.Certified,
            SentAfiniaDocuments = sale.VisitData.SentAfiniaDocuments,
            Visit = sale.VisitData.Visit
        },
        CreatedOn = sale.CreatedOn,
        UpdatedOn = sale.UpdatedOn
    };

    public IEnumerable<UserDto> ToListedUsers(IEnumerable<User> sales) => sales
        .Select(user => new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            Role = user.Role
        });

    public DeletedUserResult ToDeletedUser(User user) => new();
}

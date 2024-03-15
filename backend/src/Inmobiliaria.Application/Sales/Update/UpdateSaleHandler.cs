using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Customers.Specifications;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Properties.Specifications;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared.Exceptions;
using Inmobiliaria.Domain.Shared.Resources;
using MediatR;

namespace Inmobiliaria.Application.Sales.Create;

public class UpdateSaleHandler(ISaleRepository saleRepository, ICustomerRepository customerRepository, IPropertyRepository propertyRepository, IMapper mapper)
    : IRequestHandler<UpdateSaleCommand, UpdatedSaleResult>
{
    public async Task<UpdatedSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        Sale sale = await saleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new DomainException(Errores.ResourceNotFound, nameof(sale));

        GetCustomerByIdentitySpec customerSpecification = new(request.Customer.Identity);
        Customer? customer = await customerRepository.SingleOrDefaultAsync(customerSpecification, cancellationToken);
        if (customer is null)
        {
            customer = mapper.ToCustomer(request.Customer);
            await customerRepository.AddAsync(customer, cancellationToken);
        }
        else
        {
            customer.Identity = request.Customer.Identity;
            customer.Email = request.Customer.Email;
            customer.Names = request.Customer.Names;
            customer.LastNames = request.Customer.LastNames;
            customer.CivilStatus = request.Customer.CivilStatus;
            customer.Salary = request.Customer.Salary;
            customer.PhoneNumber = request.Customer.PhoneNumber;
        }

        GetPropertyByTuitionSpec propertySpecification = new(request.Property.Tuition);
        Property? property = await propertyRepository.SingleOrDefaultAsync(propertySpecification, cancellationToken);
        if (property is null)
        {
            property = mapper.ToProperty(request.Property);
            await propertyRepository.AddAsync(property, cancellationToken);
        }
        else
        {
            property.Tuition = request.Property.Tuition;
            property.Price = request.Property.Price;
            property.Coordinates = request.Property.Coordinates;
            property.Block = request.Property.Block;
            property.Lot = request.Property.Lot;
        }

        sale.Customer.Update(customer);
        sale.Property.Update(property);

        sale.FinancialData.LoanValue = request.FinancialData.LoanValue;
        sale.FinancialData.CompensationFundSubsidy = request.FinancialData.CompensationFundSubsidy;
        sale.FinancialData.Debt = request.FinancialData.Debt;
        sale.FinancialData.LoanEntity = request.FinancialData.LoanEntity;
        sale.FinancialData.LoanValue = request.FinancialData.LoanValue;
        sale.FinancialData.MinistryOfHousingSubsidy = request.FinancialData.MinistryOfHousingSubsidy;
        sale.FinancialData.OtherPayments = request.FinancialData.OtherPayments;
        sale.FinancialData.Price = request.FinancialData.Price;
        sale.FinancialData.ValueToSetAside = request.FinancialData.ValueToSetAside;

        sale.DocumentaryData.IdentificationDocument = request.DocumentaryData.IdentificationDocument;
        sale.DocumentaryData.SignedPledge = request.DocumentaryData.SignedPledge;
        sale.DocumentaryData.CreditApprovalLetter = request.DocumentaryData.CreditApprovalLetter;
        sale.DocumentaryData.ApprovalLetterNumber = request.DocumentaryData.ApprovalLetterNumber;
        sale.DocumentaryData.CompensationFundRecordNumber = request.DocumentaryData.CompensationFundRecordNumber;
        sale.DocumentaryData.MinistrySubsidyResolution = request.DocumentaryData.MinistrySubsidyResolution;
        sale.DocumentaryData.DeliveryDocument = request.DocumentaryData.DeliveryDocument;

        sale.AppraisalData.FamilyCodeInMinistryOfHousing = request.AppraisalData.FamilyCodeInMinistryOfHousing;
        sale.AppraisalData.IssuanceByTheBankOfALetterOfRatification = request.AppraisalData.IssuanceByTheBankOfALetterOfRatification;
        sale.AppraisalData.Payment = request.AppraisalData.Payment;
        sale.AppraisalData.Report = request.AppraisalData.Report;
        sale.AppraisalData.RequestSubmissionOfDocuments = request.AppraisalData.RequestSubmissionOfDocuments;
        sale.AppraisalData.SendingDocumentsForTitleStudy = request.AppraisalData.SendingDocumentsForTitleStudy;
        sale.AppraisalData.TitleStudyPayment = request.AppraisalData.TitleStudyPayment;
        sale.AppraisalData.Visit = request.AppraisalData.Visit;

        sale.DeedData.BankSignature = request.DeedData.BankSignature;
        sale.DeedData.ConstructionCompanySignature = request.DeedData.ConstructionCompanySignature;
        sale.DeedData.CopiesAndSettlement = request.DeedData.CopiesAndSettlement;
        sale.DeedData.CustomerSignature = request.DeedData.CustomerSignature;
        sale.DeedData.EntryDateIntoPublicInstruments = DateOnly.FromDateTime(request.DeedData.EntryDateIntoPublicInstruments.LocalDateTime);
        sale.DeedData.PropertySellerSignature = request.DeedData.PropertySellerSignature;

        sale.DeedCostsData.DeedCosts = request.DeedCostsData.DeedCosts;
        sale.DeedCostsData.DeedDebt = request.DeedCostsData.DeedDebt;
        sale.DeedCostsData.GovernmentPayment = request.DeedCostsData.GovernmentPayment;
        sale.DeedCostsData.NotaryPayment = request.DeedCostsData.NotaryPayment;
        sale.DeedCostsData.PropertyPayment = request.DeedCostsData.PropertyPayment;
        sale.DeedCostsData.PublicInstrumentsPayment = request.DeedCostsData.PublicInstrumentsPayment;

        sale.DeliveryData.DeedSentToLawyer = request.DeliveryData.DeedSentToLawyer;
        sale.DeliveryData.DisbursementInstruction = request.DeliveryData.DisbursementInstruction;
        sale.DeliveryData.PeaceAndSafetyPropertySeller = request.DeliveryData.PeaceAndSafetyPropertySeller;
        sale.DeliveryData.ScannedCTL = request.DeliveryData.ScannedCTL;
        sale.DeliveryData.ScannedDeed = request.DeliveryData.ScannedDeed;
        sale.DeliveryData.ScannedDeliveryCertificate = request.DeliveryData.ScannedDeliveryCertificate;
        sale.DeliveryData.ScannedTaxAndRegistrationSlip = request.DeliveryData.ScannedTaxAndRegistrationSlip;

        sale.SubsidyData.CompensationBoxSubsidyFiled = request.SubsidyData.CompensationBoxSubsidyFiled;
        sale.SubsidyData.CompensationCashPayment = request.SubsidyData.CompensationCashPayment;
        sale.SubsidyData.DialedMinistryCollection = request.SubsidyData.DialedMinistryCollection;
        sale.SubsidyData.LoanDisbursementDate = DateOnly.FromDateTime(request.SubsidyData.LoanDisbursementDate.LocalDateTime);
        sale.SubsidyData.MinistryPayment = request.SubsidyData.MinistryPayment;

        sale.ServicesData.ElectricMeterValue = request.ServicesData.ElectricMeterValue;
        sale.ServicesData.InstalledElectricMeter = request.ServicesData.InstalledElectricMeter;
        sale.ServicesData.InstalledWaterMeter = request.ServicesData.InstalledWaterMeter;

        sale.VisitData.Certified = request.VisitData.Certified;
        sale.VisitData.SentAfiniaDocuments = request.VisitData.SentAfiniaDocuments;
        sale.VisitData.Visit = request.VisitData.Visit;

        await saleRepository.UpdateAsync(sale, cancellationToken);

        return new UpdatedSaleResult(sale.Id);
    }
}

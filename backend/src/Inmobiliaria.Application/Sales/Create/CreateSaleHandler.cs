using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Customers.Specifications;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Properties.Specifications;
using Inmobiliaria.Domain.Sales;
using MediatR;

namespace Inmobiliaria.Application.Sales.Create;

public class CreateSaleHandler(ISaleRepository saleRepository, ICustomerRepository customerRepository, IPropertyRepository propertyRepository, IMapper mapper)
    : IRequestHandler<CreateSaleCommand, CreatedSaleResult>
{
    public async Task<CreatedSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        GetCustomerByIdentitySpec customerSpecification = new(request.Customer.Identity.Type, request.Customer.Identity.Value);
        Customer? customer = await customerRepository.SingleOrDefaultAsync(customerSpecification, cancellationToken);
        if (customer is null)
        {
            customer = mapper.ToCustomer(request.Customer);
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
        }
        else
        {
            property.Tuition = request.Property.Tuition;
            property.Price = request.Property.Price;
            property.Coordinates = request.Property.Coordinates;
            property.Block = request.Property.Block;
            property.Lot = request.Property.Lot;
        }

        SaleFinancialData financialData = mapper.ToFinancialData(request.FinancialData);
        Sale sale = new(customer, property, financialData);
        await saleRepository.AddAsync(sale, cancellationToken);

        return new CreatedSaleResult(sale.Id);
    }
}

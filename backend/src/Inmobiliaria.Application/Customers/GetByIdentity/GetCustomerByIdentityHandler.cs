using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Customers.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Customers.GetByIdentity;

public class GetCustomerByIdentityHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<GetCustomerByIdentityQuery, CustomerByIdentityResult?>
{
    public async Task<CustomerByIdentityResult?> Handle(GetCustomerByIdentityQuery request, CancellationToken cancellationToken)
    {
        GetCustomerByIdentitySpec specification = new(request.IdentityType, request.IdentityValue);
        Customer? customer = await customerRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (customer is null)
        {
            return null;
        }

        CustomerByIdentityResult result = mapper.ToCustomerByIdentity(customer);

        return result;
    }
}

using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using MediatR;

namespace Inmobiliaria.Application.Customers.GetById;

public class GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<GetCustomerByIdQuery, CustomerByIdResult?>
{
    public async Task<CustomerByIdResult?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
        {
            return null;
        }

        CustomerByIdResult result = mapper.ToCustomerById(customer);

        return result;
    }
}

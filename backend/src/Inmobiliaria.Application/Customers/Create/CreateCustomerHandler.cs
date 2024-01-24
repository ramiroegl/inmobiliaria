using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using MediatR;

namespace Inmobiliaria.Application.Customers.Create;

public class CreateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, CreatedCustomerResult>
{
    public async Task<CreatedCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = mapper.ToCustomer(request);
        await customerRepository.AddAsync(customer, cancellationToken);
        CreatedCustomerResult result = mapper.ToCreatedCustomer(customer);

        return result;
    }
}

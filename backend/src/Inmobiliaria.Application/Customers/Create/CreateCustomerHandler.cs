using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using MediatR;

namespace Inmobiliaria.Application.Customers.Create;

public class CreateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, CreatedCustomerResult>
{
    public async Task<CreatedCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = mapper.Map(request);
        await customerRepository.AddAsync(customer, cancellationToken);
        CreatedCustomerResult result = mapper.Map(customer);

        return result;
    }
}

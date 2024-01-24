using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Shared.Exceptions;
using Inmobiliaria.Domain.Shared.Resources;
using MediatR;

namespace Inmobiliaria.Application.Customers.Delete;

public class DeleteCustomerHandler(IMapper mapper, ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, DeletedCustomerResult>
{
    public async Task<DeletedCustomerResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new DomainException(Errores.ResourceNotFound, nameof(customer));

        await customerRepository.DeleteAsync(customer, cancellationToken);
        DeletedCustomerResult result = mapper.ToDeletedCustomer(customer);

        return result;
    }
}

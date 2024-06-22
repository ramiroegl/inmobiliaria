using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Customers.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Customers.Delete;

public class DeleteCustomerHandler(IMapper mapper, ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, DeletedCustomerResult>
{
    public async Task<DeletedCustomerResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        bool customerHasSales = await customerRepository.AnyAsync(new GetCustomerWithSalesSpec(request.Id), cancellationToken);
        if (customerHasSales)
        {
            return new DeletedCustomerResult(Ok: false, Error: "El cliente está siendo usado en ventas.");
        }

        Customer? customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
        {
            return new DeletedCustomerResult(Ok: false, Error: "El cliente no existe.");
        }

        await customerRepository.DeleteAsync(customer, cancellationToken);
        DeletedCustomerResult result = mapper.ToDeletedCustomer(customer);

        return result;
    }
}

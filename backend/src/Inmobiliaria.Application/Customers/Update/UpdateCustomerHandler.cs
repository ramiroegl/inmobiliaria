using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Shared;
using Inmobiliaria.Domain.Shared.Exceptions;
using Inmobiliaria.Domain.Shared.Resources;
using MediatR;

namespace Inmobiliaria.Application.Customers.Update;

public class UpdateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository, ITimeProvider timeProvider) : IRequestHandler<UpdateCustomerCommand, UpdatedCustomerResult>
{
    public async Task<UpdatedCustomerResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await customerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new DomainException(Errores.ResourceNotFound, nameof(customer));

        customer.Email = request.Email;
        customer.Names = request.Names;
        customer.LastNames = request.LastNames;
        customer.Identity = request.Identity;
        customer.CivilStatus = request.CivilStatus;
        customer.Salary = request.Salary;
        customer.PhoneNumber = request.PhoneNumber;
        customer.UpdatedOn = timeProvider.UtcNow;

        await customerRepository.UpdateAsync(customer, cancellationToken);
        UpdatedCustomerResult result = mapper.ToUpdatedCustomer(customer);

        return result;
    }
}

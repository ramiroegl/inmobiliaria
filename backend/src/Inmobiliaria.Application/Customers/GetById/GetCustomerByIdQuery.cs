using MediatR;

namespace Inmobiliaria.Application.Customers.GetById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerByIdResult>;

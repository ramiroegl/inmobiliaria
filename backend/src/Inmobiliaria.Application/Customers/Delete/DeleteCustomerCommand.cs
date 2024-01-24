using MediatR;

namespace Inmobiliaria.Application.Customers.Delete;

public record DeleteCustomerCommand(Guid Id) : IRequest<DeletedCustomerResult>;

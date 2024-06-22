using MediatR;

namespace Inmobiliaria.Application.Properties.Delete;

public record DeletePropertyCommand(Guid Id) : IRequest<DeletedPropertyResult>;

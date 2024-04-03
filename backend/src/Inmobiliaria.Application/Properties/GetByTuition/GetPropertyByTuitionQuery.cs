using MediatR;

namespace Inmobiliaria.Application.Customers.GetByTuition;

public record GetPropertyByTuitionQuery(string Tuition) : IRequest<PropertyByTuitionResult?>;

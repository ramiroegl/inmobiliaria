using Inmobiliaria.Domain.Customers;
using MediatR;

namespace Inmobiliaria.Application.Customers.GetByIdentity;

public record GetCustomerByIdentityQuery(IdentityType IdentityType, string IdentityValue) : IRequest<CustomerByIdentityResult?>;

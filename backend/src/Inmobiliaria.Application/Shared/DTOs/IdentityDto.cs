using Inmobiliaria.Domain.Customers;

namespace Inmobiliaria.Application.Shared.DTOs;

public record IdentityDto(IdentityType Type, string Value, DateTime DateOfIssue);

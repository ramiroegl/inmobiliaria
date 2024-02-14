namespace Inmobiliaria.Domain.Customers;

public record Identity(IdentityType Type, string Value, DateOnly DateOfIssue);

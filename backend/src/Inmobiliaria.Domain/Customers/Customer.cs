using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Customers;

public class Customer : Entity
{
    private string _email;
    private string _names;
    private string _lastNames;
    private string _phoneNumber;

    public required Identity Identity { get; set; }
    public required string Email { get => _email; [MemberNotNull(nameof(_email))] set => _email = value.NotNullOrWhiteSpace(); }
    public required string Names { get => _names; [MemberNotNull(nameof(_names))] set => _names = value.NotNullOrWhiteSpace(); }
    public required string LastNames { get => _lastNames; [MemberNotNull(nameof(_lastNames))] set => _lastNames = value.NotNullOrWhiteSpace(); }
    public required CivilStatus CivilStatus { get; set; }
    public required Amount Salary { get; set; }
    public required string PhoneNumber { get => _phoneNumber; [MemberNotNull(nameof(_phoneNumber))] set => _phoneNumber = value.NotNullOrWhiteSpace(); }
    public ICollection<SaleCustomer>? Sales { get; private init; }
}

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

    protected Customer() { }

    public Customer(Identity identity, string email, string names, string lastNames, CivilStatus civilStatus, Amount salary, string phoneNumber)
    {
        Identity = identity;
        Email = email;
        Names = names;
        LastNames = lastNames;
        CivilStatus = civilStatus;
        Salary = salary;
        PhoneNumber = phoneNumber;
    }

    public Identity Identity { get; set; }
    public string Email { get => _email; [MemberNotNull(nameof(_email))] set => _email = value.NotNullOrWhiteSpace(); }
    public string Names { get => _names; [MemberNotNull(nameof(_names))] set => _names = value.NotNullOrWhiteSpace(); }
    public string LastNames { get => _lastNames; [MemberNotNull(nameof(_lastNames))] set => _lastNames = value.NotNullOrWhiteSpace(); }
    public CivilStatus CivilStatus { get; set; }
    public Amount Salary { get; set; }
    public string PhoneNumber { get => _phoneNumber; [MemberNotNull(nameof(_phoneNumber))] set => _phoneNumber = value.NotNullOrWhiteSpace(); }
    public ICollection<SaleCustomer>? Sales { get; private init; }
}

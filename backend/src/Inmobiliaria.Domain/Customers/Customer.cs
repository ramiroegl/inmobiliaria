using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Customers;

public class Customer : Entity
{
    private string _email;
    private string _names;
    private string _lastNames;
    private Identity _identity;

    protected Customer() { }

    public Customer(string email, string names, string lastNames, Identity identity, CivilStatus civilStatus, Amount salary, string phoneNumber)
    {
        Email = email;
        Names = names;
        LastNames = lastNames;
        Identity = identity;
        CivilStatus = civilStatus;
        Salary = salary;
        PhoneNumber = phoneNumber;
    }

    public string Email
    {
        get => _email;
        [MemberNotNull(nameof(_email))]
        set => _email = value.NotNullOrWhiteSpace();
    }

    public string Names
    {
        get => _names;
        [MemberNotNull(nameof(_names))]
        set => _names = value.NotNullOrWhiteSpace();
    }

    public string LastNames
    {
        get => _lastNames;
        [MemberNotNull(nameof(_lastNames))]
        set => _lastNames = value.NotNullOrWhiteSpace();
    }

    public Identity Identity
    {
        get => _identity;
        [MemberNotNull(nameof(_identity))]
        set => _identity = value.NotNull();
    }

    public CivilStatus CivilStatus { get; set; }
    public Amount Salary { get; }
    public string PhoneNumber { get; }
}

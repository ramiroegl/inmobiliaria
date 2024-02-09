using System.Diagnostics.CodeAnalysis;
using Inmobiliaria.Domain.Customers;
using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class SaleCustomer : Entity
{
    private string _email;
    private string _names;
    private string _lastNames;
    private string _phoneNumber;

    protected SaleCustomer() { }

    public SaleCustomer(Customer customer)
    {
        CustomerId = customer.Id;
        Customer = customer;
        Identity = customer.Identity;
        Email = customer.Email;
        Names = customer.Names;
        LastNames = customer.LastNames;
        CivilStatus = customer.CivilStatus;
        Salary = customer.Salary;
        PhoneNumber = customer.PhoneNumber;
    }

    public Guid CustomerId { get; private init; }
    public Customer? Customer { get; private init; }
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public Identity Identity { get; set; }
    public string Email { get => _email; [MemberNotNull(nameof(_email))] set => _email = value.NotNullOrWhiteSpace(); }
    public string Names { get => _names; [MemberNotNull(nameof(_names))] set => _names = value.NotNullOrWhiteSpace(); }
    public string LastNames { get => _lastNames; [MemberNotNull(nameof(_lastNames))] set => _lastNames = value.NotNullOrWhiteSpace(); }
    public CivilStatus CivilStatus { get; set; }
    public Amount Salary { get; set; }
    public string PhoneNumber { get => _phoneNumber; [MemberNotNull(nameof(_phoneNumber))] set => _phoneNumber = value.NotNullOrWhiteSpace(); }
}

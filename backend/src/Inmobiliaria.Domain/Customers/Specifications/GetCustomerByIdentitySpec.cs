using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class GetCustomerByIdentitySpec : Specification<Customer>, ISingleResultSpecification<Customer>
{
    public GetCustomerByIdentitySpec(Identity identity) : this(identity.Type, identity.Value)
    {
    }

    public GetCustomerByIdentitySpec(IdentityType type, string value)
    {
        Query.Where(customer => customer.Identity.Type == type && customer.Identity.Value == value);
    }
}

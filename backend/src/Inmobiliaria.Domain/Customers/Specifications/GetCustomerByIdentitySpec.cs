using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class GetCustomerByIdentitySpec : Specification<Customer>, ISingleResultSpecification<Customer>
{
    public GetCustomerByIdentitySpec(IdentityType identityType, string identityValue)
    {
        Query.Where(customer => customer.Identity.Type == identityType && customer.Identity.Value == identityValue);
    }
}

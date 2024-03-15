using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class GetCustomerByIdentitySpec : Specification<Customer>, ISingleResultSpecification<Customer>
{
    public GetCustomerByIdentitySpec(Identity identity)
    {
        Query.Where(customer => customer.Identity.Type == identity.Type && customer.Identity.Value == identity.Value);
    }
}

using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class SearchCustomersSpec : Specification<Customer>
{
    public SearchCustomersSpec(string? search, int skip, int take)
    {
        if (search is not null)
        {
            var normalizedSearch = search.ToLower();
            Query
                .Where(customer => customer.Names.ToLower().Contains(normalizedSearch) || customer.LastNames.Contains(normalizedSearch));
        }

        Query.Skip(skip).Take(take);
    }
}

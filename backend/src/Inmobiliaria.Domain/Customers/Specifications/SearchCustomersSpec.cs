using Ardalis.Specification;

namespace Inmobiliaria.Domain.Customers.Specifications;

public class SearchCustomersSpec : Specification<Customer>
{
    public SearchCustomersSpec(string? search, int skip, int take)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.ToLower();
            Query
                .Where(customer =>
                    customer.Names.ToLower().Contains(normalizedSearch) ||
                    customer.LastNames.ToLower().Contains(normalizedSearch)
                );
        }
        Query.OrderBy(customer => customer.Names);
        Query.Skip(skip).Take(take);
    }
}

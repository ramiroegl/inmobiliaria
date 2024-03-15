using Ardalis.Specification;

namespace Inmobiliaria.Domain.Sales.Specifications;

public sealed class SearchSalesSpec : Specification<Sale>
{
    public SearchSalesSpec(string? search, int skip, int take)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.ToLower();
            Query
                .Where(sale =>
                    sale.Customer.Names.ToLower().Contains(normalizedSearch) ||
                    sale.Customer.LastNames.ToLower().Contains(normalizedSearch)
                );
        }
        Query.OrderByDescending(sale => sale.UpdatedOn);
        Query.Skip(skip).Take(take);
    }
}

using Ardalis.Specification;

namespace Inmobiliaria.Domain.Properties.Specifications;

public class SearchPropertiesSpec : Specification<Property>
{
    public SearchPropertiesSpec(string? search, int skip, int take)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalizedSearch = search.ToLower();
            Query
                .Where(property =>
                    property.Tuition.ToLower().Contains(normalizedSearch) ||
                    property.Lot.ToLower().Contains(normalizedSearch) ||
                    property.Block.ToLower().Contains(normalizedSearch)
                );
        }
        Query.OrderBy(property => property.Tuition);
        Query.Skip(skip).Take(take);
    }
}

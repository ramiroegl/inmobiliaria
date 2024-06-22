using Ardalis.Specification;

namespace Inmobiliaria.Domain.Properties.Specifications;

public class GetPropertyWithSalesSpec : Specification<Property>
{
    public GetPropertyWithSalesSpec(Guid id)
    {
        Query
            .Where(property => property.Id == id && property.Sales != null && property.Sales.Count > 0);
    }
}

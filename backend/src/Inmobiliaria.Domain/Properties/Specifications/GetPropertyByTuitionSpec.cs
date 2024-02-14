using Ardalis.Specification;

namespace Inmobiliaria.Domain.Properties.Specifications;

public class GetPropertyByTuitionSpec : Specification<Property>, ISingleResultSpecification<Property>
{
    public GetPropertyByTuitionSpec(string tuition)
    {
        Query.Where(property => property.Tuition == tuition);
    }
}

using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Properties.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Properties.List;

public class ListPropertiesHandler(IPropertyRepository propertyRepository, IMapper mapper) : IRequestHandler<ListPropertiesQuery, ListedPropertiesResult>
{
    public async Task<ListedPropertiesResult> Handle(ListPropertiesQuery request, CancellationToken cancellationToken)
    {
        var specification = new SearchPropertiesSpec(request.Search, request.Skip, request.Take);
        List<Property> properties = await propertyRepository.ListAsync(specification, cancellationToken);
        var totalOfCustomers = await propertyRepository.CountAsync(specification, cancellationToken);

        return new ListedPropertiesResult
        {
            Data = mapper.ToListedProperties(properties),
            PageSize = request.Take,
            TotalRecords = totalOfCustomers
        };
    }
}

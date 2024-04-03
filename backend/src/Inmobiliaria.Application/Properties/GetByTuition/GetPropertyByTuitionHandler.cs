using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Properties.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Customers.GetByTuition;

public class GetPropertyByTuitionHandler(IPropertyRepository propertyRepository, IMapper mapper) : IRequestHandler<GetPropertyByTuitionQuery, PropertyByTuitionResult?>
{
    public async Task<PropertyByTuitionResult?> Handle(GetPropertyByTuitionQuery request, CancellationToken cancellationToken)
    {
        GetPropertyByTuitionSpec specification = new(request.Tuition);
        Property? property = await propertyRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (property is null)
        {
            return null;
        }

        PropertyByTuitionResult result = mapper.ToPropertyByTuition(property);

        return result;
    }
}

using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Properties;
using MediatR;

namespace Inmobiliaria.Application.Properties.Create;

public class CreatePropertyHandler(IPropertyRepository propertyRepository, IMapper mapper) : IRequestHandler<CreatePropertyCommand, CreatedPropertyResult>
{
    public async Task<CreatedPropertyResult> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
    {
        Property property = mapper.ToProperty(request);
        await propertyRepository.AddAsync(property, cancellationToken);
        CreatedPropertyResult result = mapper.ToCreatedProperty(property);

        return result;
    }
}

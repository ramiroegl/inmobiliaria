using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Properties;
using Inmobiliaria.Domain.Properties.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Properties.Delete;

public class DeletePropertyHandler(IMapper mapper, IPropertyRepository propertyRepository) : IRequestHandler<DeletePropertyCommand, DeletedPropertyResult>
{
    public async Task<DeletedPropertyResult> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
    {
        bool propertyHasSales = await propertyRepository.AnyAsync(new GetPropertyWithSalesSpec(request.Id), cancellationToken);
        if (propertyHasSales)
        {
            return new DeletedPropertyResult(Ok: false, Error: "La propiedad está siendo usada en ventas.");
        }

        Property? property = await propertyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (property is null)
        {
            return new DeletedPropertyResult(Ok: false, Error: "La propiedad no existe.");
        }

        await propertyRepository.DeleteAsync(property, cancellationToken);
        DeletedPropertyResult result = mapper.ToDeletedProperty(property);

        return result;
    }
}

using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Shared.Exceptions;
using Inmobiliaria.Domain.Shared.Resources;
using MediatR;

namespace Inmobiliaria.Application.Sales.GetById;

public record GetSaleByIdQuery(Guid Id) : IRequest<SaleDto>;

public class GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<GetSaleByIdQuery, SaleDto>
{
    public async Task<SaleDto> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
    {
        Sale? sale = await saleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new DomainException(Errores.ResourceNotFound, nameof(sale));

        return mapper.ToSale(sale);
    }
}

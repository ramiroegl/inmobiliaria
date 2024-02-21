using Inmobiliaria.Application.Shared;
using Inmobiliaria.Domain.Sales;
using Inmobiliaria.Domain.Sales.Specifications;
using MediatR;

namespace Inmobiliaria.Application.Sales.List;

public class ListSalesHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<ListSalesQuery, ListedSalesResult>
{
    public async Task<ListedSalesResult> Handle(ListSalesQuery request, CancellationToken cancellationToken)
    {
        var specification = new SearchSalesSpec(request.Search, request.Skip, request.Take);
        List<Sale> sales = await saleRepository.ListAsync(specification, cancellationToken);
        var totalOfSales = await saleRepository.CountAsync(specification, cancellationToken);

        return new ListedSalesResult
        {
            Data = mapper.ToListedSales(sales),
            PageSize = request.Take,
            TotalRecords = totalOfSales
        };
    }
}

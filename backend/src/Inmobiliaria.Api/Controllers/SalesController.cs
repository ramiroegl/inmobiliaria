using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.GetById;
using Inmobiliaria.Application.Sales.List;
using Inmobiliaria.Application.Sales.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SalesController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public Task<CreatedSaleResult> CreateAsync(CreateSaleCommand request, CancellationToken cancellationToken)
        => mediator.Send(request, cancellationToken);

    [HttpGet]
    public Task<ListedSalesResult> ListAsync([FromQuery] ListSalesQuery query, CancellationToken cancellationToken)
        => mediator.Send(query, cancellationToken);

    [HttpGet("{id:guid}")]
    public Task<SaleDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => mediator.Send(new GetSaleByIdQuery(id), cancellationToken);

    [HttpPut("{id:guid}")]
    public Task<UpdatedSaleResult> UpdateAsync(Guid id, UpdateSaleCommand request, CancellationToken cancellationToken)
        => mediator.Send(request with { Id = id }, cancellationToken);
}

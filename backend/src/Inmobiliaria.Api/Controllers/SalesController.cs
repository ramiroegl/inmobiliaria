using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

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

    [HttpPut("{id:guid}")]
    public Task<UpdatedSaleResult> UpdateAsync(Guid id, UpdateSaleCommand request, CancellationToken cancellationToken)
        => mediator.Send(request with { Id = id }, cancellationToken);
}

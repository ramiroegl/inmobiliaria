using Inmobiliaria.Application.Sales.Create;
using Inmobiliaria.Application.Sales.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CreatedSaleResult> Create(CreateSaleCommand command, CancellationToken cancellationToken) =>
        sender.Send(command, cancellationToken);

    [HttpGet]
    public Task<ListedSalesResult> List([FromQuery] ListSalesQuery query, CancellationToken cancellationToken) =>
        sender.Send(query, cancellationToken);
}

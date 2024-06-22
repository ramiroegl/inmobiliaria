using Inmobiliaria.Application.Customers.GetByTuition;
using Inmobiliaria.Application.Properties.Create;
using Inmobiliaria.Application.Properties.Delete;
using Inmobiliaria.Application.Properties.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PropertiesController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CreatedPropertyResult> Create(CreatePropertyCommand command, CancellationToken cancellation)
        => sender.Send(command, cancellation);

    [HttpGet("get-by-tuition")]
    public async Task<ActionResult<PropertyByTuitionResult?>> Get([FromQuery] GetPropertyByTuitionQuery query, CancellationToken cancellation)
    {
        PropertyByTuitionResult? response = await sender.Send(query, cancellation);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpGet]
    public Task<ListedPropertiesResult> List([FromQuery] ListPropertiesQuery query, CancellationToken cancellation)
        => sender.Send(query, cancellation);

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeletedPropertyResult?>> Delete(Guid id, CancellationToken cancellation)
    {
        DeletedPropertyResult? response = await sender.Send(new DeletePropertyCommand(id), cancellation);
        return response is null ? NotFound() : Ok(response);
    }
}

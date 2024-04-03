using Inmobiliaria.Application.Customers.GetByTuition;
using Inmobiliaria.Application.Properties.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

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
}

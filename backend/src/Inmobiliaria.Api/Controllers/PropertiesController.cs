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
}

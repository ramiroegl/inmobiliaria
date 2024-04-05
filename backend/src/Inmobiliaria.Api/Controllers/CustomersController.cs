using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.GetByIdentity;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CustomersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CreatedCustomerResult> CreateAsync(CreateCustomerCommand command, CancellationToken cancellation)
        => sender.Send(command, cancellation);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerByIdResult?>> Get(Guid id, CancellationToken cancellation)
    {
        CustomerByIdResult? response = await sender.Send(new GetCustomerByIdQuery(id), cancellation);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpGet]
    public Task<ListedCustomersResult> List([FromQuery] ListCustomersQuery query, CancellationToken cancellation)
        => sender.Send(query, cancellation);

    [HttpPut("{id:guid}")]
    public Task<UpdatedCustomerResult> Update(Guid id, UpdateCustomerCommand command, CancellationToken cancellation)
    {
        command = command with { Id = id };
        return sender.Send(command, cancellation);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<DeletedCustomerResult?>> Delete(Guid id, CancellationToken cancellation)
    {
        DeletedCustomerResult? response = await sender.Send(new DeleteCustomerCommand(id), cancellation);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpGet("get-by-identity")]
    public async Task<ActionResult<CustomerByIdentityResult?>> Get([FromQuery] GetCustomerByIdentityQuery query, CancellationToken cancellation)
    {
        CustomerByIdentityResult? response = await sender.Send(query, cancellation);
        return response is null ? NotFound() : Ok(response);
    }
}

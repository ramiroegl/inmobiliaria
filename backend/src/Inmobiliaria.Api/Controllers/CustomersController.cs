using Inmobiliaria.Application.Customers.Create;
using Inmobiliaria.Application.Customers.Delete;
using Inmobiliaria.Application.Customers.GetById;
using Inmobiliaria.Application.Customers.List;
using Inmobiliaria.Application.Customers.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CreatedCustomerResult> Create(CreateCustomerCommand command, CancellationToken cancellation) =>
        sender.Send(command, cancellation);

    [HttpGet("{id:guid}")]
    public Task<CustomerByIdResult> Get(Guid id, CancellationToken cancellation) =>
        sender.Send(new GetCustomerByIdQuery(id), cancellation);

    [HttpGet]
    public Task<ListedCustomersResult> List([FromQuery] ListCustomersQuery query, CancellationToken cancellation) =>
        sender.Send(query, cancellation);

    [HttpPut("{id:guid}")]
    public Task<UpdatedCustomerResult> Update(Guid id, UpdateCustomerCommand command, CancellationToken cancellation)
    {
        command = command with { Id = id };
        return sender.Send(command, cancellation);
    }

    [HttpDelete("{id:guid}")]
    public Task<DeletedCustomerResult> Delete(Guid id, CancellationToken cancellation) =>
        sender.Send(new DeleteCustomerCommand(id), cancellation);
}

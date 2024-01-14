using Inmobiliaria.Application.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CreatedCustomerResult> Create(CreateCustomerCommand command, CancellationToken cancellation) => sender.Send(command, cancellation);
}

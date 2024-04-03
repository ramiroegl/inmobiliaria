using Inmobiliaria.Api.Models;
using Inmobiliaria.Application.Users;
using Inmobiliaria.Application.Users.GetByCredentials;
using Inmobiliaria.Infrastructure.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ISender mediator, TokenService tokenService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<ActionResult<LoginCredentials>> LoginAsync(GetUserByCredentialsQuery request, CancellationToken cancellationToken)
    {
        UserDto? user = await mediator.Send(request, cancellationToken);

        if (user is null)
        {
            return BadRequest();
        }

        string token = tokenService.Generate(user);

        return Ok(new LoginCredentials { Token = token, User = user });
    }
}

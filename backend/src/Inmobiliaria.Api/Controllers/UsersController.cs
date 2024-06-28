using Inmobiliaria.Api.Models;
using Inmobiliaria.Application.Users.Create;
using Inmobiliaria.Application.Users.Delete;
using Inmobiliaria.Application.Users.GetByCredentials;
using Inmobiliaria.Application.Users.List;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Infrastructure.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController(ISender mediator, TokenService tokenService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CreatedUserResult>> CreateAsync(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreatedUserResult? user = await mediator.Send(request, cancellationToken);

        if (user is null)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    [HttpGet]
    public Task<ListedUsersResult> ListAsync([FromQuery] ListUsersQuery query, CancellationToken cancellationToken)
        => mediator.Send(query, cancellationToken);

    [AllowAnonymous]
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

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DeletedUserResult?>> Delete(Guid id, CancellationToken cancellation)
    {
        DeletedUserResult response = await mediator.Send(new DeleteUserCommand(id), cancellation);
        return response is null ? NotFound() : Ok(response);
    }
}

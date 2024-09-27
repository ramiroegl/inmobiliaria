using Inmobiliaria.Api.Models;
using Inmobiliaria.Application.Users.ChangePassword;
using Inmobiliaria.Application.Users.Create;
using Inmobiliaria.Application.Users.Delete;
using Inmobiliaria.Application.Users.GetByCredentials;
using Inmobiliaria.Application.Users.GetById;
using Inmobiliaria.Application.Users.List;
using Inmobiliaria.Application.Users.Shared;
using Inmobiliaria.Application.Users.Update;
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
    [AllowAnonymous]
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

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UpdatedUserResult>> UpdateAsync(Guid id, UpdateUserCommand request, CancellationToken cancellationToken)
    {
        request = request with { UserId = id };

        UpdatedUserResult? result = await mediator.Send(request, cancellationToken);

        return result is null ? BadRequest() : Ok(result);
    }

    [HttpPut("Me")]
    public async Task<ActionResult<UpdatedUserResult>> UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(User.Claims.Single(x => x.Type == TokenDefaults.IdClaim).Value, out Guid userId))
        {
            return Unauthorized();
        }

        request = request with { UserId = userId };

        UpdatedUserResult? result = await mediator.Send(request, cancellationToken);

        return result is null ? BadRequest() : Ok(result);
    }


    [HttpGet("Me")]
    public async Task<ActionResult<UserByIdResult>> GetMeAsync(CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(User.Claims.Single(x => x.Type == TokenDefaults.IdClaim).Value, out Guid userId))
        {
            return Unauthorized();
        }

        GetUserByIdQuery request = new() { Id = userId };

        UserByIdResult? result = await mediator.Send(request, cancellationToken);

        return result is null ? Unauthorized() : Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserByIdResult>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        GetUserByIdQuery request = new() { Id = id };

        UserByIdResult? result = await mediator.Send(request, cancellationToken);

        return result is null ? Unauthorized() : Ok(result);
    }

    [HttpPut("Me/Change-Password")]
    public async Task<ActionResult<ChangedPasswordResult?>> ChangePassword(UpdatePasswordModel model, CancellationToken cancellation)
    {
        GetUserByCredentialsQuery loginRequest = new()
        {
            Email = User.Claims.Single(x => x.Type == TokenDefaults.MailClaim).Value,
            Password = model.Password
        };

        UserDto? loginResult = await mediator.Send(loginRequest, cancellation);
        if (loginResult is null)
        {
            return BadRequest();
        }

        ChangePasswordCommand changePasswordRequest = new()
        {
            Id = loginResult.Id,
            NewPassword = model.NewPassword
        };

        ChangedPasswordResult? changedPasswordResult = await mediator.Send(changePasswordRequest, cancellation);
        if (changedPasswordResult is null)
        {
            return BadRequest();
        }

        return Ok(changedPasswordResult);
    }

    [HttpPut("{id:guid}/Reset-Password")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ChangedPasswordResult?>> ResetPassword(Guid id, ResetPasswordModel model, CancellationToken cancellation)
    {
        ChangePasswordCommand changePasswordRequest = new()
        {
            Id = id,
            NewPassword = model.NewPassword
        };

        ChangedPasswordResult? changedPasswordResult = await mediator.Send(changePasswordRequest, cancellation);
        if (changedPasswordResult is null)
        {
            return BadRequest();
        }

        return Ok(changedPasswordResult);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DeletedUserResult?>> Delete(Guid id, CancellationToken cancellation)
    {
        DeletedUserResult response = await mediator.Send(new DeleteUserCommand(id), cancellation);
        return response is null ? BadRequest() : Ok(response);
    }
}

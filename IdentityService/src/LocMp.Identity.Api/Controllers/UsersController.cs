using LocMp.Identity.Application.DTOs.Common;
using LocMp.Identity.Application.DTOs.User;
using LocMp.Identity.Application.Identity.Queries.Users.GetUserByEmail;
using LocMp.Identity.Application.Identity.Queries.Users.GetUserById;
using LocMp.Identity.Application.Identity.Queries.Users.GetUserByPhoneNumber;
using LocMp.Identity.Application.Identity.Queries.Users.GetUserByUsername;
using LocMp.Identity.Application.Identity.Queries.Users.GetUsersByRoleId;
using LocMp.Identity.Application.Identity.Queries.Users.GetUsersPaged;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocMp.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserDto>>> GetUsers([FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await mediator.Send(new GetUsersPagedQuery(page, pageSize));
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("by-email")]
    public async Task<ActionResult<UserDto>> GetByEmail([FromQuery] string email)
    {
        var result = await mediator.Send(new GetUserByEmailQuery(email));
        return Ok(result);
    }

    [HttpGet("by-role/{roleId:guid}")]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetByRoleId(Guid roleId)
    {
        var result = await mediator.Send(new GetUsersByRoleIdQuery(roleId));
        return Ok(result);
    }

    [HttpGet("by-username")]
    public async Task<ActionResult<UserDto>> GetByUsername([FromQuery] string username)
    {
        var result = await mediator.Send(new GetUserByUsernameQuery(username));
        return Ok(result);
    }

    [HttpGet("by-phone")]
    public async Task<ActionResult<UserDto>> GetByPhone([FromQuery] string phone)
    {
        var result = await mediator.Send(new GetUserByPhoneNumberQuery(phone));
        return Ok(result);
    }
}
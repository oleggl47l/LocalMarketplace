using LocMp.Identity.Application.DTOs.Role;
using LocMp.Identity.Application.Identity.Queries.Roles.GetRoleById;
using LocMp.Identity.Application.Identity.Queries.Roles.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocMp.Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<RoleDto>>> GetRoles()
    {
        var result = await mediator.Send(new GetRolesQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RoleDto>> GetById(Guid id)
    {
        var result = await mediator.Send(new GetRoleByIdQuery(id));
        return Ok(result);
    }
}
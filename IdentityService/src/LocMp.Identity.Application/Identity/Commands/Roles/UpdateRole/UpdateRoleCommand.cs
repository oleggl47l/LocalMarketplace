using LocMp.Identity.Application.DTOs.Role;
using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Roles.UpdateRole;

public sealed record UpdateRoleCommand(
    Guid Id,
    string Name,
    bool Active = true
) : IRequest<RoleDto>;
using LocMp.Identity.Application.DTOs.Role;
using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Roles.CreateRole;

public sealed record CreateRoleCommand(
    string Name,
    bool Active = true
) : IRequest<RoleDto>;
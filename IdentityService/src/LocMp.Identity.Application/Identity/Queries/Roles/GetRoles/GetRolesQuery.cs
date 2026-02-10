using LocMp.Identity.Application.DTOs.Role;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Roles.GetRoles;

public sealed record GetRolesQuery : IRequest<IReadOnlyList<RoleDto>>;


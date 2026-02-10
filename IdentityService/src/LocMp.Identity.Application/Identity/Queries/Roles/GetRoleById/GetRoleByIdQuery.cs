using LocMp.Identity.Application.DTOs.Role;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Roles.GetRoleById;

public sealed record GetRoleByIdQuery(Guid Id) : IRequest<RoleDto>;
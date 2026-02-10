using LocMp.Identity.Domain.Enums;
using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Users.UpdateUserRoles;

public sealed record UpdateUserRolesCommand(
    Guid UserId,
    IReadOnlyCollection<UserRole> Roles
) : IRequest<Unit>;
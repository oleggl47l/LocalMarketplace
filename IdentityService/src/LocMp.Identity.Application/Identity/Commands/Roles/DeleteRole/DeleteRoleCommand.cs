using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Roles.DeleteRole;

public sealed record DeleteRoleCommand(Guid Id) : IRequest<Unit>;
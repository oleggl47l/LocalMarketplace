using LocMp.Identity.Application.DTOs.User;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Users.GetUsersByRoleId;

public sealed record GetUsersByRoleIdQuery(Guid RoleId) : IRequest<IReadOnlyList<UserDto>>;


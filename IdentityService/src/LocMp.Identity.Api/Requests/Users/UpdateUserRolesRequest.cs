using LocMp.Identity.Domain.Enums;

namespace LocMp.Identity.Api.Requests.Users;

public sealed record UpdateUserRolesRequest(IReadOnlyCollection<UserRole> Roles);
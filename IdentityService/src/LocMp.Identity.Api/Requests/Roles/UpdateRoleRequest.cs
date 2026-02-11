namespace LocMp.Identity.Api.Requests.Roles;

public sealed record UpdateRoleRequest(
    string Name,
    bool Active = true
);
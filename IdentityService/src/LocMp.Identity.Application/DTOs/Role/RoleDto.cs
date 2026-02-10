namespace LocMp.Identity.Application.DTOs.Role;

public sealed record RoleDto(
    Guid Id,
    string Name,
    bool Active
);


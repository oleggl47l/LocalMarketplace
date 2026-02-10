namespace LocMp.Identity.Application.DTOs.User;

public sealed record UserDto(
    Guid Id,
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    int? Gender,
    string PhoneNumber,
    DateTime RegisteredAt,
    bool Active
);


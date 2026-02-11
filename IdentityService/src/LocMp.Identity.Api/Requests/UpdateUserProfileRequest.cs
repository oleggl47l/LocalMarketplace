using LocMp.Identity.Domain.Enums;

namespace LocMp.Identity.Api.Requests;

public sealed record UpdateUserProfileRequest(
    string? FirstName,
    string? LastName,
    Gender? Gender,
    DateTime? BirthDate,
    string? PhoneNumber
);
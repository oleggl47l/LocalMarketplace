using LocMp.Identity.Application.DTOs.UserProfile;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.UserProfile.GetUserProfile;

public sealed record GetUserProfileQuery(Guid UserId) : IRequest<UserProfileDto>;
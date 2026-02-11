using LocMp.Identity.Application.DTOs.UserProfile;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.UserProfile.GetUserPhoto;

public sealed record GetUserPhotoQuery(Guid UserId) : IRequest<UserPhotoDto>;
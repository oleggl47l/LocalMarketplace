using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.UserProfile.DeleteUserPhoto;

public sealed record DeleteUserPhotoCommand(Guid UserId) : IRequest;
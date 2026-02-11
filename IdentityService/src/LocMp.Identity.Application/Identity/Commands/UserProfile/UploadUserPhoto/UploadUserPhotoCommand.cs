using MediatR;
using Microsoft.AspNetCore.Http;

namespace LocMp.Identity.Application.Identity.Commands.UserProfile.UploadUserPhoto;

public sealed record UploadUserPhotoCommand(Guid UserId, IFormFile Photo) : IRequest;
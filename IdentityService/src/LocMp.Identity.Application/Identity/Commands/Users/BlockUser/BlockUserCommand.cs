using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Users.BlockUser;

public sealed record BlockUserCommand(Guid UserId, int DurationInMinutes) : IRequest<Unit>;
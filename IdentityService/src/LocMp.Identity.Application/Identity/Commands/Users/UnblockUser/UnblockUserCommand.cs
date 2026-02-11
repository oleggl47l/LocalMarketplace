using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Users.UnblockUser;

public sealed record UnblockUserCommand(Guid UserId) : IRequest<Unit>;
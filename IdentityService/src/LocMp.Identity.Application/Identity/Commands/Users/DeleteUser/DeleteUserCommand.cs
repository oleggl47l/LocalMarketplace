using MediatR;

namespace LocMp.Identity.Application.Identity.Commands.Users.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Unit>;
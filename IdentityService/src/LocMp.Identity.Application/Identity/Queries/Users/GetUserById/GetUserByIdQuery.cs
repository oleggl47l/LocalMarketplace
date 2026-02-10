using LocMp.Identity.Application.DTOs.User;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Users.GetUserById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;


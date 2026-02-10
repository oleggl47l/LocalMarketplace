using LocMp.Identity.Application.DTOs.User;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Users.GetUserByUsername;

public sealed record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
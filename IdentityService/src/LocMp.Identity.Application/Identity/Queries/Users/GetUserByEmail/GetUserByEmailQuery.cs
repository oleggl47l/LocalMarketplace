using LocMp.Identity.Application.DTOs.User;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Users.GetUserByEmail;

public sealed record GetUserByEmailQuery(string Email) : IRequest<UserDto>;
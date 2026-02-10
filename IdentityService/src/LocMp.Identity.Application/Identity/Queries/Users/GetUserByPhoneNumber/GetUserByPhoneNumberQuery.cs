using LocMp.Identity.Application.DTOs.User;
using MediatR;

namespace LocMp.Identity.Application.Identity.Queries.Users.GetUserByPhoneNumber;

public sealed record GetUserByPhoneNumberQuery(string PhoneNumber) : IRequest<UserDto>;
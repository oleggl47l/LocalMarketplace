using System.Security.Claims;
using MediatR;
using OpenIddict.Abstractions;

namespace LocMp.Identity.Application.Identity.Commands.ExchangeToken;

public sealed record ExchangeTokenCommand(OpenIddictRequest Request) : IRequest<ClaimsPrincipal>;
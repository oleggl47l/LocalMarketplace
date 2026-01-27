using LocMp.Identity.Application.Identity.Commands;
using LocMp.Identity.Application.Identity.Commands.ExchangeToken;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace LocMp.Identity.Api.Controllers;

[ApiController]
public sealed class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("connect/token")]
    [IgnoreAntiforgeryToken]
    public async Task<ActionResult<OpenIddictRequest>> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest()
                      ?? throw new InvalidOperationException("Invalid OIDC request.");

        var principal = await mediator.Send(new ExchangeTokenCommand(request));
        return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}
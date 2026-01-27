using System.Security.Claims;
using LocMp.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;

namespace LocMp.Identity.Application.Identity.Commands.ExchangeToken;

public sealed class ExchangeTokenCommandHandler(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IRequestHandler<ExchangeTokenCommand, ClaimsPrincipal>
{
    public async Task<ClaimsPrincipal> Handle(ExchangeTokenCommand command, CancellationToken ct)
    {
        var request = command.Request;

        if (!request.IsPasswordGrantType())
            throw new NotImplementedException("Only Password grant is supported.");

        var user = await userManager.FindByNameAsync(request.Username!)
                   ?? throw new UnauthorizedAccessException("Invalid credentials.");

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password!, true);

        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Invalid credentials.");

        var principal = await signInManager.CreateUserPrincipalAsync(user);

        var userId = await userManager.GetUserIdAsync(user);

        principal.SetClaim(OpenIddictConstants.Claims.Subject, userId);

        principal.SetScopes(new[]
        {
            OpenIddictConstants.Scopes.OpenId,
            OpenIddictConstants.Scopes.Email,
            OpenIddictConstants.Scopes.Profile,
            OpenIddictConstants.Scopes.OfflineAccess
        }.Intersect(request.GetScopes()));

        foreach (var claim in principal.Claims)
        {
            var destinations = new List<string> { OpenIddictConstants.Destinations.AccessToken };

            if (claim.Type is ClaimTypes.Name or ClaimTypes.Email &&
                principal.HasScope(OpenIddictConstants.Scopes.Profile))
                destinations.Add(OpenIddictConstants.Destinations.IdentityToken);

            claim.SetDestinations(destinations);
        }

        return principal;
    }
}
using System.Security.Claims;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using LocMp.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LocMp.Identity.Infrastructure.Services;

public class ProfileService(
    UserManager<ApplicationUser> userManager,
    IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
    : ProfileService<ApplicationUser>(userManager, claimsFactory)
{
    public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        await base.GetProfileDataAsync(context);

        var user = await UserManager.GetUserAsync(context.Subject);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new("email", user.Email ?? ""),
                new("username", user.UserName ?? "")
            };

            var roles = await UserManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            context.IssuedClaims.AddRange(claims);
        }
    }
}
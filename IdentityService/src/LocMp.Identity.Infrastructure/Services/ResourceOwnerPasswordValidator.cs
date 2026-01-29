using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using LocMp.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocMp.Identity.Infrastructure.Services;

public class ResourceOwnerPasswordValidator(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager)
    : IResourceOwnerPasswordValidator
{
    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var user = await userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == context.UserName ||
                                      u.Email == context.UserName ||
                                      u.PhoneNumber == context.UserName);

        if (user is not { Active: true })
        {
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "Invalid credentials or account is not active");
            return;
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, context.Password, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            context.Result = new GrantValidationResult(
                subject: user.Id.ToString(),
                authenticationMethod: "password");
            return;
        }

        var errorDescription = result.IsLockedOut
            ? "Account temporarily locked"
            : "Invalid credentials";

        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, errorDescription);
    }
}
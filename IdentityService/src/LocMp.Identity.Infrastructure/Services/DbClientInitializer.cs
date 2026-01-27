using LocMp.Identity.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenIddict.Abstractions;

namespace LocMp.Identity.Infrastructure.Services;

public class DbClientInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken ct)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync(ct);

        var appManager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
        var scopeManager = scope.ServiceProvider.GetRequiredService<IOpenIddictScopeManager>();

        await EnsureScopeAsync(scopeManager, OpenIddictConstants.Scopes.Email, ct);
        await EnsureScopeAsync(scopeManager, OpenIddictConstants.Scopes.Profile, ct);

        if (await appManager.FindByClientIdAsync("default-client", ct) is null)
        {
            await appManager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "default-client",
                DisplayName = "Default Client",
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.Password,
                    OpenIddictConstants.Permissions.GrantTypes.RefreshToken,

                    OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.Email,
                    OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.Profile,
                    OpenIddictConstants.Permissions.Prefixes.Scope + OpenIddictConstants.Scopes.OpenId,
                }
            }, ct);
        }
    }

    private static async Task EnsureScopeAsync(IOpenIddictScopeManager manager, string name, CancellationToken ct)
    {
        if (await manager.FindByNameAsync(name, ct) is null)
        {
            await manager.CreateAsync(new OpenIddictScopeDescriptor { Name = name }, ct);
        }
    }

    public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
}
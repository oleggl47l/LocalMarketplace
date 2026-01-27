namespace LocMp.Identity.Infrastructure.Options;

public sealed class IdentityServerSettings
{
    public List<ClientSettings> Clients { get; init; } = [];
}

public sealed class ClientSettings
{
    public string ClientId { get; init; } = null!;
    public List<string> AllowedScopes { get; init; } = [];
    public int AccessTokenLifetime { get; init; }
    public bool AllowOfflineAccess { get; init; } = true;
}
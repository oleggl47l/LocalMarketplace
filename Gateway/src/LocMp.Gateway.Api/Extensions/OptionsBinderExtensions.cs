using LocMp.Gateway.Api.Options;

namespace LocMp.Gateway.Api.Extensions;

public static class OptionsBinderExtensions
{
    public static void ConfigureOptions(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<CorsPoliticsOptions>()
            .Bind(config.GetSection("CorsPoliticsOptions"))
            .ValidateDataAnnotations();

        services.AddOptions<AuthenticationOptions>()
            .Bind(config.GetSection("AuthenticationOptions"))
            .ValidateDataAnnotations();
    }
}
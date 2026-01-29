using Microsoft.OpenApi;

namespace LocMp.Gateway.Api.Extensions;

public static class SwaggerExtensions
{
    public static void AddDocumentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway API", Version = "v1" }); });

        services.AddSwaggerForOcelot(config);
    }
}
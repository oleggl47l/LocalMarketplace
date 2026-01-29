using Serilog;

namespace LocMp.Gateway.Api.Extensions;

public static class LoggingExtensions
{
    public static void AddSerilogLogging(this IHostBuilder host)
    {
        host.UseSerilog((context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console();
        });
    }
}
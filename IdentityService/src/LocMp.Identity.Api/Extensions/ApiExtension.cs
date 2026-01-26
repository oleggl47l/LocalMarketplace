using System.Text.Json.Serialization;
using LocMp.Identity.Api.Handlers;

namespace LocMp.Identity.Api.Extensions;

public static class ApiExtension
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
}
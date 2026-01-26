using LocMp.Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocMp.Identity.Infrastructure.Extensions;

public static class DbExtension
{
    public static void AddDbExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LocMpIdentityDb")
                               ?? throw new InvalidOperationException("Connection string 'LocMpIdentityDb' not found.");
        services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(connectionString); });
    }
}
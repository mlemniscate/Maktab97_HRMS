using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DbContextConfigurationExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, Action<DbContextOptions> dbContextOptionsAction)
    {
        services.Configure(dbContextOptionsAction);
        services.AddScoped<IDbContext, DbContext>();
    }
}
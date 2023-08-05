using Application;
using Domain.Repository;
using Infrastructure.Repository;
using Persistence;

namespace UI.Tools;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.ConfigureDbContext(options =>
            options.ConnectionString = configuration.GetConnectionString("Default"));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}
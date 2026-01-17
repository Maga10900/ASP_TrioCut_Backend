using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TriVibe.DAL.SqlServer.DbContexts;
namespace TriVibe.DAL.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerDALServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TrioCutDb>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}

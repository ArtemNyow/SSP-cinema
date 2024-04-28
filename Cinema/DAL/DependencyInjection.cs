using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DependencyInjection
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DB_URL");
        services.AddDbContext<CinemaDbContext>((optionsBuilder) => optionsBuilder.UseSqlServer(connectionString));
    }
}
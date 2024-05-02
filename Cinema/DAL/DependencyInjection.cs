using DAL.Interfaces;
using DAL.Repositories;
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
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
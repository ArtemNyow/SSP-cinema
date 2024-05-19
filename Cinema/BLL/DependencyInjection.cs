using System.Text;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BLL
{
    public static class DependencyInjection
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStatisticService, StatisticService>();
        }
    }
}

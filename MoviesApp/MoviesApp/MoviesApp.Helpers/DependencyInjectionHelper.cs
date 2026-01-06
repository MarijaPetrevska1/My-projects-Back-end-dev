using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess;
using MoviesApp.DataAccess.Implementations;
using MoviesApp.Services.Interfaces;
using SEDC.MoviesApp.Services.Implementations;

namespace MoviesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void INjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<MoviesDbContext>(x =>
               x.UseSqlServer("Server=.;Database=MoviesDbTest;Trusted_Connection=True"));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}

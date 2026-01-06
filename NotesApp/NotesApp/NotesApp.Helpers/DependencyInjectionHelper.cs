using NotesApp.DataAccess;
using NotesApp.DataAccess.AdoImplementations;
using NotesApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.DataAccess;
using NotesApp.DataAccess.AdoImplementations;
using NotesApp.DataAccess.Implemenations;
using NotesApp.Domain.Models;

namespace Avenga.NotesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotesAppDbContext>(x =>
            x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
        }

        public static void InjectDapperRepositories(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<Note>>(x => new NoteDapperRepository(connectionString));
        }

        public static void InjectAdoRepositories(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<Note>>(x => new NoteAdoRepository(connectionString));
        }
    }
}

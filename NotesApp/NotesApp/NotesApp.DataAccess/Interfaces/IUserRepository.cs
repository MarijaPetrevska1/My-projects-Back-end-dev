using NotesApp.Domain.Models;
using NotesApp.DataAccess;
using NotesApp.Domain.Models;

namespace Avenga.NotesApp.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string hashedPassword);
    }
}

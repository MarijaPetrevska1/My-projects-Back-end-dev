using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.DataAccess.Implemenations
{
    public class UserRepository : IRepository<User>
    {
        private NotesAppDbContext _notesAppDbContext;

        public UserRepository(NotesAppDbContext notesDbContext)
        {
            _notesAppDbContext = notesDbContext;
        }

        public void Add(User entity)
        {
            _notesAppDbContext.Users.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _notesAppDbContext.Users.Remove(entity);
            _notesAppDbContext.SaveChanges();  
        }

        public List<User> GetAll()
        {
            return _notesAppDbContext.Users.Include(x => x.Notes).ToList();
        }

        public User GetById(int id)
        {
            return _notesAppDbContext.Users.Include(x => x.Notes).FirstOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
            _notesAppDbContext.Users.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NotesApp.DataAccess.Implemenations
{
    // Dependency Injection(DI) е техника каде една класа добива работи
    // што ѝ се потребни однадвор, наместо сама да ги создава.
    // IRepository<Note> кажува кои методи мора да ги има(GetAll, GetById, Add, Update, Delete)
    public class NoteRepository : IRepository<Note>
    {
        // Constructor
        private NotesAppDbContext _notesAppDbContext;

        public NoteRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        // Методи
        public void Add(Note entity)
        {
            _notesAppDbContext.Notes.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(Note entity)
        {
            _notesAppDbContext.Notes.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return _notesAppDbContext.Notes.Include(x => x.User).ToList();
        }

        public Note GetById(int id)
        {
            return _notesAppDbContext.Notes.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Note entity)
        {
            _notesAppDbContext.Notes.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}

using NotesApp.Dtos.NoteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Services.Interfaces
{
    // CRUD операции
    public interface INoteService
    {
        List<NoteDto> GetAllNotes();
        NoteDto GetById(int id);
        void AddNote(AddNoteDto note);
        void UpdateNote(UpdateNoteDto note);
        void DeleteNote(int id);
    }
}

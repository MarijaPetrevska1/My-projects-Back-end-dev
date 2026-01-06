using NotesApp.Domain.Models;
using NotesApp.Dtos.NoteDtos;
using NotesApp.Services.Interfaces;
using NotesApp.DataAccess.Implemenations;
using NotesApp.DataAccess;
using NotesApp.Shared.CustomExceptions;
using NotesApp.Mappers;

namespace NotesApp.Services.Implementations
{
    public class NoteService:INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }
        public List<NoteDto> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public NoteDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddNote(AddNoteDto addNoteDto)
        {
            User userDb = _userRepository.GetById(addNoteDto.UserId);
            if(userDb == null)
            {
                throw new NoteDataException($"User with id {addNoteDto.UserId} does not exist!");
            }
            if(string.IsNullOrEmpty(addNoteDto.Text))
            {
                throw new NoteDataException("Text Field is required!");
            }
            if(addNoteDto.Text.Length > 100)
            {
                throw new NoteDataException("Text canot contain more than 100 characters.");
            }

            Note newNote = addNoteDto.ToNote();
            _noteRepository.Add(newNote);
        }

        public void UpdateNote(UpdateNoteDto note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

     
    }
}

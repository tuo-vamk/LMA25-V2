using LMA25_V2.Interfaces;
using LMA25_V2.Models;

namespace LMA25_V2.Services
{
    internal class NoteService : INoteService
    {
        public Task AddNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        //private readonly AppDbContext _context;
        //public NoteService(AppDbContext notesDbContext) 
        //{
        //    _context = notesDbContext;
        //}
        //public async Task AddNoteAsync(Note note)
        //{
        //    _context.Notes.Add(note);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<List<Note>> GetNotesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

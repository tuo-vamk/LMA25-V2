using LMA25_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMA25_V2.Interfaces
{
    public interface INoteService
    {
        Task<List<Note>> GetNotesAsync();
        Task AddNoteAsync(Note note);
    }
}

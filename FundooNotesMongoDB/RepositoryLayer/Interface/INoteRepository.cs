using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface INoteRepository
    {
        Task<NoteModel> AddNote(NoteModel note);
        Task<NoteModel> UpdateNote(NoteModel note);
        Task<bool> DeleteNote(NoteModel note);
        IEnumerable<NoteModel> GetAllNotes();

        Task<NoteModel> ChangeColour(NoteModel note); 
        Task<NoteModel> ArchiveNote(NoteModel note);
        Task<NoteModel> Remainder(NoteModel note);
        
        Task<NoteModel> Trash(NoteModel note);
        Task<NoteModel> Pin(NoteModel note);
    }
}

using BussinessLayer.Interface;
using DataBaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Bussiness
{
    public class NoteBL : INoteBL
    {
        private readonly INoteRepository repo;
        public NoteBL(INoteRepository repo)
        {
            this.repo = repo;
        }

        public async Task<NoteModel> AddNote(NoteModel note)
        {

            try
            {
                return await this.repo.AddNote(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> ArchiveNote(NoteModel note)
        {
            try
            {
                return await this.repo.ArchiveNote(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> ChangeColour(NoteModel note)
        {

            try
            {
                return await this.repo.ChangeColour(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteNote(NoteModel note)
        {
            try
            {
                return await this.repo.DeleteNote(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {

            try
            {
                return  this.repo.GetAllNotes();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> Pin(NoteModel note)
        {
            try
            {
                return await this.repo.Pin(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> Remainder(NoteModel note)
        {
            try
            {
                return await this.repo.Remainder(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> Trash(NoteModel note)
        {
            try
            {
                return await this.repo.Trash(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> UpdateNote(NoteModel note)
        {
            try
            {
                return await this.repo.UpdateNote(note);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

using DataBaseLayer;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMongoCollection<NoteModel> Note;
        private readonly IConfiguration configuration;

        public NoteRepository(IDBSetting db, IConfiguration configuration)
        {

            this.configuration = configuration;
            var userclient = new MongoClient(db.ConnectionString);
            var database = userclient.GetDatabase(db.DatabaseName);
            Note = database.GetCollection<NoteModel>("Note");
        }

        public async Task<NoteModel> AddNote(NoteModel note)
        {
            try
            {
                var check = this.Note.AsQueryable().Where(x => x.NoteID == note.NoteID).SingleOrDefault();
                if (check == null)
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
                return null;
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> ArchiveNote(NoteModel note)
        {
            try
            {
                var check = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (check != null)
                {
                    if (note.IsArchive == true)
                    {
                        note.IsArchive = false;
                    }

                    if (note.IsArchive == false)
                    {
                        note.IsArchive = true;
                    }
                    return check;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> ChangeColour(NoteModel note)
        {
            try
            {
                var ifExists = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (ifExists != null)
                {
                    await this.Note.UpdateOneAsync(x => x.NoteID == note.NoteID,
                        Builders<NoteModel>.Update.Set(x => x.Color, note.Color));
                    return ifExists;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteNote(NoteModel note)
        {
            try
            {
                var ifExists = await this.Note.FindOneAndDeleteAsync(x => x.NoteID == note.NoteID);
                return true;

            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {
                return Note.Find(FilterDefinition<NoteModel>.Empty).ToList();
        }

        public async Task<NoteModel> Pin(NoteModel note)
        {
            try
            {
                var check = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (check != null)
                {
                    if (note.IsPin == true)
                    {
                        note.IsPin = false;
                    }

                    if (note.IsPin == false)
                    {
                        note.IsPin = true;
                    }
                    return check;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> Remainder(NoteModel note)
        {
            try
            {
                var ifExists = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (ifExists != null)
                {
                    await this.Note.UpdateOneAsync(x => x.NoteID == note.NoteID,
                        Builders<NoteModel>.Update.Set(x => x.IsRemainder, note.IsRemainder)
                        .Set(x => x.Remainder, note.Remainder));
                    return ifExists;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> Trash(NoteModel note)
        {
            try
            {
                var check = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (check != null)
                {
                    if (note.IsTrash == true)
                    {
                        note.IsTrash = false;
                    }

                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                    }
                    return check;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<NoteModel> UpdateNote(NoteModel note)
        {
            try
            {
                var ifExists = await this.Note.Find(x => x.NoteID == note.NoteID).SingleOrDefaultAsync();
                if (ifExists != null)
                {
                    await this.Note.UpdateOneAsync(x => x.NoteID == note.NoteID,
                        Builders<NoteModel>.Update.Set(x => x.Title, note.Title)
                        .Set(x => x.Description, note.Description)
                        .Set(x => x.Color, note.Color)
                        .Set(x => x.IsPin, note.IsPin)
                        .Set(x => x.IsArchive, note.IsArchive)
                        .Set(x => x.IsRemainder, note.IsRemainder)
                        .Set(x => x.IsTrash, note.IsPin));
                    return ifExists;

                }
                else
                {
                    await this.Note.InsertOneAsync(note);
                    return note;
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

        

       

        

        
    


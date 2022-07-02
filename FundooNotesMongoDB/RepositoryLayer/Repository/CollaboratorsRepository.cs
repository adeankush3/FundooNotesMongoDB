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
    public class CollaboratorsRepository : ICollaboratorsRepository
    {
        private readonly IMongoCollection<CollaboratorsModel> Collaborator;
        private readonly IConfiguration configuration;

        public CollaboratorsRepository(IDBSetting db, IConfiguration configuration)
        {

            this.configuration = configuration;
            var userclient = new MongoClient(db.ConnectionString);
            var database = userclient.GetDatabase(db.DatabaseName);
            Collaborator = database.GetCollection<CollaboratorsModel>("Collaborator");
        }

        public async Task<CollaboratorsModel> AddCollaborators(CollaboratorsModel Collaborators)
        {
            try
            {
                var check =  this.Collaborator.AsQueryable().Where(x => x.CollaboratorsID == Collaborators.CollaboratorsID).SingleOrDefault();
                if (check == null)
                {
                    await this.Collaborator.InsertOneAsync(Collaborators);
                    return Collaborators;
                }
                return null;
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CollaboratorsModel> GetAllCollaborators()
        {
            return Collaborator.Find(FilterDefinition<CollaboratorsModel>.Empty).ToList();
        }

        public async Task<bool> RemoveCollaborators(CollaboratorsModel collaborators)
        {
            try
            {
                var ifExists = await this.Collaborator.FindOneAndDeleteAsync(x => x.CollaboratorsID == collaborators.CollaboratorsID);
                return true;

            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

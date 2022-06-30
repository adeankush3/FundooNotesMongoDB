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
    public class LabelRepository : ILabelRepository
    {
        private readonly IMongoCollection<LabelModel> Labels;
        private readonly IConfiguration configuration;

        public LabelRepository(IDBSetting db, IConfiguration configuration)
        {

            this.configuration = configuration;
            var userclient = new MongoClient(db.ConnectionString);
            var database = userclient.GetDatabase(db.DatabaseName);
            Labels = database.GetCollection<LabelModel>("Labels");
        }

        public async Task<LabelModel> AddLabel(LabelModel label)
        {
            try
            {
                var check =  this.Labels.AsQueryable().Where(x => x.LabelId == label.LabelId).SingleOrDefault();
                if (check == null)
                {
                    await this.Labels.InsertOneAsync(label);
                    return label;
                }
                return null;
            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteLabel(LabelModel label)
        {
            try
            {
                var ifExists = await this.Labels.FindOneAndDeleteAsync(x => x.LabelId == label.LabelId);
                return true;

            }
            catch (ArgumentNullException e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<LabelModel> GetAllLabels()
        {
            return Labels.Find(FilterDefinition<LabelModel>.Empty).ToList();
        }
    }
}

using BussinessLayer.Interface;
using DataBaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Bussiness
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRepository repo;
        public LabelBL(ILabelRepository repo)
        {
            this.repo = repo;
        }

        public async Task<LabelModel> AddLabel(LabelModel label)
        {
            try
            {
                return await this.repo.AddLabel(label);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteLabel(LabelModel label)
        {
            try
            {
                return await this.repo.DeleteLabel(label);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<LabelModel> GetAllLabels()
        {
            try
            {
                return  this.repo.GetAllLabels();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

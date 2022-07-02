using BussinessLayer.Interface;
using DataBaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Bussiness
{
    public class CollaboratorsBL : ICollaboratorsBL
    {
        private readonly ICollaboratorsRepository repo;
        public CollaboratorsBL(ICollaboratorsRepository repo)
        {
            this.repo = repo;
        }

        public async Task<CollaboratorsModel> AddCollaborators(CollaboratorsModel Collaborators)
        {
            try
            {
                return await this.repo.AddCollaborators(Collaborators);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CollaboratorsModel> GetAllCollaborators()
        {
            try
            {
                return  this.repo.GetAllCollaborators();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> RemoveCollaborators(CollaboratorsModel collaborators)
        {
            try
            {
                return await this.repo.RemoveCollaborators(collaborators);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

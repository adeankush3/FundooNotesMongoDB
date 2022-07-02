using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratorsRepository
    {
        Task<CollaboratorsModel> AddCollaborators(CollaboratorsModel collaborators);
        Task<bool> RemoveCollaborators(CollaboratorsModel collaborators);

        IEnumerable<CollaboratorsModel> GetAllCollaborators();
    }
}

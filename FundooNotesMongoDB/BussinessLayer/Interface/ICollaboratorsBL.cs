using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface ICollaboratorsBL
    {
        Task<CollaboratorsModel> AddCollaborators(CollaboratorsModel Collaborators);

        Task<bool> RemoveCollaborators(CollaboratorsModel collaborators);
        IEnumerable<CollaboratorsModel> GetAllCollaborators();
    }
}

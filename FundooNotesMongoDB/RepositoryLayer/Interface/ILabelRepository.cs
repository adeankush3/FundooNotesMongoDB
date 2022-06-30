using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ILabelRepository
    {
        Task<LabelModel> AddLabel(LabelModel label);
        Task<bool> DeleteLabel(LabelModel label);
        IEnumerable<LabelModel> GetAllLabels();
    }
}

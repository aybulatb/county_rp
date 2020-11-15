using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IModeratorRepository
    {
        Task<IEnumerable<Moderator>> GetAll();
        Task<Moderator> GetById(int id);
    }
}

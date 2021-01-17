using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface IModeratorRepository
    {
        Task<IEnumerable<Moderator>> GetAll();
        Task<Moderator> GetById(int id);
        Task<Moderator> Create(Moderator moderator);
        Task<Moderator> Edit(int id, Moderator moderator);
        Task Delete(int id);
    }
}

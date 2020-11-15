using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<IEnumerable<Moderator>> GetAll();
        Task<Moderator> GetById(int id);
    }
}

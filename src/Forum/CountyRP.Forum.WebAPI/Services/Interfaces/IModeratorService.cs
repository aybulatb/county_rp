using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<IEnumerable<Moderator>> GetAll();
        Task<Moderator> GetById(int id);
        Task<Moderator> Create(ModeratorViewModel moderatorModel);
        Task<Moderator> Edit(int id, ModeratorEditViewModel moderatorEditModel);
        Task Delete(int id);
    }
}

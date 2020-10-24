using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IGameBanAdapter
    {
        Task<GameBan> GetById(int id);
        Task<FilteredModels<GameBan>> FilterBy(int page, int count);
        Task<GameBan> Create(GameBan gameBan);
        Task<GameBan> Edit(int id, GameBan gameBan);
        Task Delete(int id);
    }
}

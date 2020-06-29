using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAdapter
    {
        Task<Player> Register(Player player);
        Task<Player> TryAuthorize(string login, string password);
        Task<Player> GetById(int id);
        Task<Player> GetByLogin(string login);
        Task<Player> Edit(int id, Player player);
        Task<FilteredModels<Player>> FilterBy(int page, int count, string name);
    }
}

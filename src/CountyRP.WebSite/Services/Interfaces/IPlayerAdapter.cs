using System.Threading.Tasks;
using CountyRP.Models;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAdapter
    {
        Task<Player> Register(Player player);
        Task<Player> TryAuthorize(string login, string password);
        Task<Player> GetById(int id);
        Task<Player> GetByLogin(string login);
    }
}

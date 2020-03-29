using System.Threading.Tasks;
using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAdapter
    {
        Task<Player> GetById(int id);
        Task<Player> GetByLogin(string login);
    }
}

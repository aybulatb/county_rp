using System.Threading.Tasks;

using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IAllPlayerAdapter
    {
        Task<AllPlayer> GetByLogin(string login);
    }
}

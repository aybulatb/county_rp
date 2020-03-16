using System.Threading.Tasks;

using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAuthorizationAdapter
    {
        Task<Player> TryAuthorize(string login, string password);
    }
}

using System.Threading.Tasks;

using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPlayerAuthorizationAdapter
    {
        /// <exception cref="CountyRP.WebSite.Exceptions.AdapterException">
        /// StatusCode 400 - player is not found
        /// </exception>
        Task<Player> TryAuthorize(string login, string password);
    }
}

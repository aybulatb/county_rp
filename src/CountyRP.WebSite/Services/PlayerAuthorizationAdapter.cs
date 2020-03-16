using System.Threading.Tasks;

using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.Extra;

namespace CountyRP.WebSite.Services
{
    public class PlayerAuthorizationAdapter : IPlayerAuthorizationAdapter 
    {
        private PlayerAuthorizationClient _playerAuthorizationClient;

        public PlayerAuthorizationAdapter(PlayerAuthorizationClient playerAuthorizationClient)
        {
            _playerAuthorizationClient = playerAuthorizationClient;
        }

        public async Task<Player> TryAuthorize(string login, string password)
        {
            Player player;

            try
            {
                player = await _playerAuthorizationClient.TryAuthorizeAsync(login, password);
            }
            catch (ApiException ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Message);
            }

            return player;
        }
    }
}

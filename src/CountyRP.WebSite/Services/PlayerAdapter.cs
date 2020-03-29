using System.Threading.Tasks;
using CountyRP.Extra;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class PlayerAdapter : IPlayerAdapter
    {
        private PlayerClient _playerClient;

        public PlayerAdapter(PlayerClient playerClient)
        {
            _playerClient = playerClient;
        }

        public async Task<Player> GetById(int id)
        {
            Player player;

            try
            {
                player = await _playerClient.GetByIdAsync(id);
            }
            catch (ApiException ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Message);
            }

            return player;
        }

        public async Task<Player> GetByLogin(string login)
        {
            Player player;

            try
            {
                player = await _playerClient.GetByLoginAsync(login);
            }
            catch (ApiException ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Message);
            }

            return player;
        }
    }
}

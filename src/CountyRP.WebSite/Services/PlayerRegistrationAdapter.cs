using System.Threading.Tasks;

using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public class PlayerRegistrationAdapter : IPlayerRegistrationAdapter
    {
        private PlayerRegistrationClient _playerRegistrationClient;

        public PlayerRegistrationAdapter(PlayerRegistrationClient playerRegistrationClient)
        {
            _playerRegistrationClient = playerRegistrationClient;
        }

        public async Task Register(string login, string password)
        {
            try
            {
                await _playerRegistrationClient.RegisterAsync(login, password);
            }
            catch (ApiException)
            {
                return;
            }

            return;
        }
    }
}

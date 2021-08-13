using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services
{
    public partial class GameService : IGameService
    {
        private PlayerClient _playerClient;

        public GameService(
            PlayerClient playerClient
        )
        {
            _playerClient = playerClient;
        }
    }
}

using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game
{
    public partial class GameService : IGameService
    {
        private PlayerClient _playerClient;
        private PersonClient _personClient;

        public GameService(
            PlayerClient playerClient,
            PersonClient personClient
        )
        {
            _playerClient = playerClient ?? throw new ArgumentNullException(nameof(playerClient));
            _personClient = personClient ?? throw new ArgumentNullException(nameof(personClient));
        }
    }
}

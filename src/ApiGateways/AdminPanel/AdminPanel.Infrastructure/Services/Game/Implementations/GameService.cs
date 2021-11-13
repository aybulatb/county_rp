using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Implementations
{
    public partial class GameService : IGameService
    {
        private PlayerClient _playerClient;
        private PersonClient _personClient;
        private PlayerWithPersonsClient _playerWithPersonsClient;

        public GameService(
            PlayerClient playerClient,
            PersonClient personClient,
            PlayerWithPersonsClient playerWithPersonsClient
        )
        {
            _playerClient = playerClient ?? throw new ArgumentNullException(nameof(playerClient));
            _personClient = personClient ?? throw new ArgumentNullException(nameof(personClient));
            _playerWithPersonsClient = playerWithPersonsClient ?? throw new ArgumentNullException(nameof(playerWithPersonsClient));
        }
    }
}

using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces
{
    public partial interface IGameService
    {
        Task<GamePlayerWithPersonsDtoOut> GetPlayerWithPersonsByPlayerIdAsync(int playerId);

        Task<GamePagedFilterResultDtoOut<GamePlayerWithPersonsDtoOut>> GetPlayersWithPersonsByFilterAsync(
            GamePlayerWithPersonsFilterDtoIn filter
        );
    }
}

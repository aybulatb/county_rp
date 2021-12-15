using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Player;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces
{
    public partial interface IGameService
    {
        Task<GamePlayerDtoOut> GetPlayerByIdAsync(int id);

        Task<GamePagedFilterResultDtoOut<GamePlayerDtoOut>> GetPlayersByFilterAsync(GamePlayerFilterDtoIn gameFilterPlayerDtoIn);

        Task UpdatePlayerAsync(int id, GameEditedPlayerDtoIn editedPlayerDtoIn);

        Task DeletePlayerAsync(int id);
    }
}

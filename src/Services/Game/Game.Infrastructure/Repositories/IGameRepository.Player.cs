using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<PlayerDtoOut> AddPlayerAsync(PlayerDtoIn playerDtoIn);

        public Task<PagedFilterResultDtoOut<PlayerDtoOut>> GetPlayersByFilter(PlayerFilterDtoIn filter);

        public Task<PlayerDtoOut> UpdatePlayerAsync(EditedPlayerDtoIn editedPlayerDtoIn);

        public Task DeletePlayerByFilter(PlayerFilterDtoIn filter);
    }
}

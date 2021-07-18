using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<TeleportDtoOut> AddTeleportAsync(TeleportDtoIn teleportDtoIn);

        public Task<PagedFilterResultDtoOut<TeleportDtoOut>> GetTeleportsByFilter(TeleportFilterDtoIn filter);

        public Task<TeleportDtoOut> UpdateTeleportAsync(TeleportDtoOut teleportDtoOut);

        public Task DeleteTeleportByFilter(TeleportFilterDtoIn filter);
    }
}

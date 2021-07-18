using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<FactionDtoOut> AddFactionAsync(FactionDtoIn factionDtoIn);

        public Task<PagedFilterResultDtoOut<FactionDtoOut>> GetFactionsByFilter(FactionFilterDtoIn filter);

        public Task<FactionDtoOut> UpdateFactionAsync(FactionDtoOut factionDtoOut);

        public Task DeleteFactionByFilter(FactionFilterDtoIn filter);
    }
}

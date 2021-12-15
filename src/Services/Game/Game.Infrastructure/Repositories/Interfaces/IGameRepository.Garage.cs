using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Interfaces
{
    public partial interface IGameRepository
    {
        public Task<GarageDtoOut> AddGarageAsync(GarageDtoIn garageDtoIn);

        public Task<PagedFilterResultDtoOut<GarageDtoOut>> GetGaragesByFilter(GarageFilterDtoIn filter);

        public Task<GarageDtoOut> UpdateGarageAsync(GarageDtoOut garageDtoOut);

        public Task DeleteGarageByFilter(GarageFilterDtoIn filter);
    }
}

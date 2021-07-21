using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<AtmDtoOut> AddAtmAsync(AtmDtoIn atmDtoIn);

        public Task<PagedFilterResultDtoOut<AtmDtoOut>> GetAtmsByFilter(AtmFilterDtoIn filter);

        public Task<AtmDtoOut> UpdateAtmAsync(AtmDtoOut atmDtoOut);

        public Task DeleteAtmByFilter(AtmFilterDtoIn filter);
    }
}

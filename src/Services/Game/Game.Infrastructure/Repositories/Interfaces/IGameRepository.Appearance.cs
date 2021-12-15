using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Interfaces
{
    public partial interface IGameRepository
    {
        public Task<AppearanceDtoOut> AddAppearanceAsync(AppearanceDtoIn appearanceDtoIn);

        public Task<PagedFilterResultDtoOut<AppearanceDtoOut>> GetAppearancesByFilter(AppearanceFilterDtoIn filter);

        public Task<AppearanceDtoOut> UpdateAppearanceAsync(AppearanceDtoOut appearanceDtoOut);

        public Task DeleteAppearanceByFilter(AppearanceFilterDtoIn filter);
    }
}

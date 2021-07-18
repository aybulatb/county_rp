using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<AdminLevelDtoOut> AddAdminLevelAsync(AdminLevelDtoIn adminLevelDtoIn);

        public Task<PagedFilterResultDtoOut<AdminLevelDtoOut>> GetAdminLevelsByFilter(AdminLevelFilterDtoIn filter);

        public Task<AdminLevelDtoOut> UpdateAdminLevelAsync(AdminLevelDtoOut adminLevelDtoOut);

        public Task DeleteAdminLevelByFilter(AdminLevelFilterDtoIn filter);
    }
}

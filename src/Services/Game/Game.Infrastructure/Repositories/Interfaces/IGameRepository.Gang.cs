using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Interfaces
{
    public partial interface IGameRepository
    {
        public Task<GangDtoOut> AddGangAsync(GangDtoIn gangDtoIn);

        public Task<PagedFilterResultDtoOut<GangDtoOut>> GetGangsByFilter(GangFilterDtoIn filter);

        public Task<GangDtoOut> UpdateGangAsync(EditedGangDtoIn editedGangDtoIn);

        public Task DeleteGangByFilter(GangFilterDtoIn filter);
    }
}

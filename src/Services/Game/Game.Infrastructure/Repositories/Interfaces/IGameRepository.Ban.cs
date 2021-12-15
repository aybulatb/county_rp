using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Interfaces
{
    public partial interface IGameRepository
    {
        Task<BanDtoOut> AddBanAsync(BanDtoIn banDtoIn);

        Task<BanDtoOut> GetBanAsync(int id);

        Task<PagedFilterResultDtoOut<BanDtoOut>> GetBansByFilterAsync(BanFilterDtoIn filter);

        Task UpdateBanAsync(BanDtoOut banDtoOut);

        Task DeleteBanAsync(int id);
    }
}

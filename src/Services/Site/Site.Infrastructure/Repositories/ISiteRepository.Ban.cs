using CountyRP.Services.Site.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Infrastructure.Repositories
{
    public partial interface ISiteRepository
    {
        Task<BanDtoOut> AddBanAsync(BanDtoIn banDtoIn);

        Task<BanDtoOut> GetBanAsync(int id);

        Task<BanDtoOut> GetBanByUserIdAsync(int userId);

        Task<PagedFilterResult<BanDtoOut>> GetBansByFilterAsync(BanFilterDtoIn filter);

        Task<BanDtoOut> UpdateBanAsync(BanDtoOut banDtoOut);

        Task DeleteBanAsync(int id);
    }
}

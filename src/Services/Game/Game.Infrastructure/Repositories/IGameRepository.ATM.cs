using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<ATMDtoOut> AddATMAsync(ATMDtoIn atmDtoIn);

        public Task<PagedFilterResultDtoOut<ATMDtoOut>> GetATMsByFilter(ATMFilterDtoIn filter);

        public Task<ATMDtoOut> UpdateATMAsync(ATMDtoOut atmDtoOut);

        public Task DeleteATMByFilter(ATMFilterDtoIn filter);
    }
}

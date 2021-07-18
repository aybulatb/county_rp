using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<BusinessDtoOut> AddBusinessAsync(BusinessDtoIn businessDtoIn);

        public Task<PagedFilterResultDtoOut<BusinessDtoOut>> GetBusinesssByFilter(BusinessFilterDtoIn filter);

        public Task<BusinessDtoOut> UpdateBusinessAsync(BusinessDtoOut businessDtoOut);

        public Task DeleteBusinessByFilter(BusinessFilterDtoIn filter);
    }
}

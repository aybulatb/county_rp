using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<VehicleDtoOut> AddVehicleAsync(VehicleDtoIn vehicleDtoIn);

        public Task<PagedFilterResultDtoOut<VehicleDtoOut>> GetVehiclesByFilter(VehicleFilterDtoIn filter);

        public Task<VehicleDtoOut> UpdateVehicleAsync(VehicleDtoOut vehicleDtoOut);

        public Task DeleteVehicleByFilter(VehicleFilterDtoIn filter);
    }
}

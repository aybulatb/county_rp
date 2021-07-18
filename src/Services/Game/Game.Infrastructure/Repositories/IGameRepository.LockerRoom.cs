using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<LockerRoomDtoOut> AddLockerRoomAsync(LockerRoomDtoIn lockerRoomDtoIn);

        public Task<PagedFilterResultDtoOut<LockerRoomDtoOut>> GetLockerRoomsByFilter(LockerRoomFilterDtoIn filter);

        public Task<LockerRoomDtoOut> UpdateLockerRoomAsync(LockerRoomDtoOut lockerRoomDtoOut);

        public Task DeleteLockerRoomByFilter(LockerRoomFilterDtoIn filter);
    }
}

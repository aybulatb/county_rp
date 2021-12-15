using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Interfaces
{
    public partial interface IGameRepository
    {
        public Task<RoomDtoOut> AddRoomAsync(RoomDtoIn roomDtoIn);

        public Task<PagedFilterResultDtoOut<RoomDtoOut>> GetRoomsByFilter(RoomFilterDtoIn filter);

        public Task<RoomDtoOut> UpdateRoomAsync(RoomDtoOut roomDtoOut);

        public Task DeleteRoomByFilter(RoomFilterDtoIn filter);
    }
}

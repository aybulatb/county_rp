using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class RoomIdConverter
    {
        public static RoomFilterDtoIn ToRoomFilterDtoIn(
            int source
        )
        {
            return new RoomFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                name: null,
                nameLike: null,
                gangIds: null,
                startLastPaymentDate: null,
                finishLastPaymentDate: null
            );
        }
    }
}

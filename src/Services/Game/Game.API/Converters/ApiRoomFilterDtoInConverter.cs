using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiRoomFilterDtoInConverter
    {
        public static RoomFilterDtoIn ToRepository(
            ApiRoomFilterDtoIn source
        )
        {
            return new RoomFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                name: source.Name,
                nameLike: source.NameLike,
                gangIds: source.GangIds,
                startLastPaymentDate: source.StartLastPaymentDate,
                finishLastPaymentDate: source.FinishLastPaymentDate
            );
        }
    }
}

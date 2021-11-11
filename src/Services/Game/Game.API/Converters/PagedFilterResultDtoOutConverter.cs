using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PagedFilterResultDtoOutConverter
    {
        public static ApiPagedFilterResultDtoOut<ApiPlayerDtoOut> ToApi(
            PagedFilterResultDtoOut<PlayerDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiPlayerDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(PlayerDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiPersonDtoOut> ToApi(
            PagedFilterResultDtoOut<PersonDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiPersonDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(PersonDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiPlayerWithPersonsDtoOut> ToApi(
            PagedFilterResultDtoOut<PlayerDtoOut> source,
            IEnumerable<PersonDtoOut> persons
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiPlayerWithPersonsDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(player =>
                        PlayerDtoOutConverter.ToApi(
                            source: player,
                            persons: persons
                                .Where(person => person.PlayerId == player.Id)
                        )
                    )
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiAdminLevelDtoOut> ToApi(
            PagedFilterResultDtoOut<AdminLevelDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiAdminLevelDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(AdminLevelDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiAppearanceDtoOut> ToApi(
            PagedFilterResultDtoOut<AppearanceDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiAppearanceDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(AppearanceDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiAtmDtoOut> ToApi(
            PagedFilterResultDtoOut<AtmDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiAtmDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(AtmDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiBusinessDtoOut> ToApi(
            PagedFilterResultDtoOut<BusinessDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiBusinessDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(BusinessDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiFactionDtoOut> ToApi(
            PagedFilterResultDtoOut<FactionDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiFactionDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(FactionDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiGangDtoOut> ToApi(
            PagedFilterResultDtoOut<GangDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiGangDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(GangDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiGarageDtoOut> ToApi(
            PagedFilterResultDtoOut<GarageDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiGarageDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(GarageDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiHouseDtoOut> ToApi(
            PagedFilterResultDtoOut<HouseDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiHouseDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(HouseDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiLockerRoomDtoOut> ToApi(
            PagedFilterResultDtoOut<LockerRoomDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiLockerRoomDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(LockerRoomDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiRoomDtoOut> ToApi(
            PagedFilterResultDtoOut<RoomDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiRoomDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(RoomDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiTeleportDtoOut> ToApi(
            PagedFilterResultDtoOut<TeleportDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiTeleportDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(TeleportDtoOutConverter.ToApi)
            );
        }

        public static ApiPagedFilterResultDtoOut<ApiVehicleDtoOut> ToApi(
            PagedFilterResultDtoOut<VehicleDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiVehicleDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(VehicleDtoOutConverter.ToApi)
            );
        }
    }
}

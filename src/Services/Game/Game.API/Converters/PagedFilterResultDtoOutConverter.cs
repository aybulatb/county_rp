using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
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

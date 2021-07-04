using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.API.Converters
{
    public static class ApiLogUnitDtoInConverter
    {
        public static LogUnitDtoIn ToRepository(
            ApiLogUnitDtoIn source
        )
        {
            return new LogUnitDtoIn(
                dateTime: source.DateTime,
                login: source.Login,
                ip: source.IP,
                actionId: ApiLogActionDtoConverter.ToRepository(source.ActionId),
                text: source.Text
            );
        }
    }
}

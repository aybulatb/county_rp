using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;

namespace CountyRP.Services.Logs.Converters
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

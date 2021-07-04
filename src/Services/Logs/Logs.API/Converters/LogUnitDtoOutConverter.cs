using CountyRP.Services.Logs.API.Models;
using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.API.Converters
{
    public static class LogUnitDtoOutConverter
    {
        public static ApiLogUnitDtoOut ToApi(
            LogUnitDtoOut source
        )
        {
            return new ApiLogUnitDtoOut(
                id: source.Id,
                dateTime: source.DateTime,
                login: source.Login,
                ip: source.IP,
                actionId: LogActionDtoConverter.ToApi(source.ActionId),
                text: source.Text
            );
        }
    }
}

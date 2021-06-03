using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;

namespace CountyRP.Services.Logs.Converters
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

using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class LogsLogUnitDtoOutConverter
    {
        public static ApiLogUnitDtoOut ToApi(
            LogsLogUnitDtoOut source
        )
        {
            return new ApiLogUnitDtoOut(
                id: source.Id,
                dateTime: source.DateTime,
                login: source.Login,
                ip: source.IP,
                actionType: LogsLogActionTypeDtoConverter.ToApi(source.ActionType),
                text: source.Text
            );
        }
    }
}

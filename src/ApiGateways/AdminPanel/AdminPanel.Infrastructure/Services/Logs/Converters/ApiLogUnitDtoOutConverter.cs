using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters
{
    internal static class ApiLogUnitDtoOutConverter
    {
        public static LogsLogUnitDtoOut ToService(
            ApiLogUnitDtoOut source
        )
        {
            return new LogsLogUnitDtoOut(
                Id: source.Id,
                DateTime: source.DateTime,
                Login: source.Login,
                IP: source.Ip,
                ActionType: ApiLogActionDtoConverter.ToService(source.ActionId),
                Text: source.Text
            );
        }
    }
}

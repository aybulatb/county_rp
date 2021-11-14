using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters
{
    internal static class LogsLogUnitDtoInConverter
    {
        public static ApiLogUnitDtoIn ToExternalApi(
            LogsLogUnitDtoIn source
        )
        {
            return new ApiLogUnitDtoIn
            {
                DateTime = source.DateTime,
                Login = source.Login,
                Ip = source.IP,
                ActionId = LogsLogActionTypeDtoConverter.ToExternalApi(source.ActionType),
                Text = source.Text
            };
        }
    }
}

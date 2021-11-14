using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal class ApiLogUnitDtoInConverter
    {
        public static LogsLogUnitDtoIn ToService(
            ApiLogUnitDtoIn source
        )
        {
            return new LogsLogUnitDtoIn(
                DateTime: source.DateTime,
                Login: source.Login,
                IP: source.IP,
                ActionType: ApiLogActionTypeDtoConverter.ToService(source.ActionType),
                Text: source.Text
            );
        }
    }
}

using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiLogUnitFilterDtoInConverter
    {
        public static LogsLogUnitFilterDtoIn ToService(
            ApiLogUnitFilterDtoIn source
        )
        {
            return new LogsLogUnitFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                Ids: source.Ids,
                StartDateTime: source.StartDateTime,
                FinishDateTime: source.FinishDateTime,
                Login: source.Login,
                IP: source.IP,
                ActionType: source.ActionType.HasValue
                    ? ApiLogActionTypeDtoConverter.ToService(source.ActionType.Value)
                    : null,
                Text: source.Text
            );
        }
    }
}

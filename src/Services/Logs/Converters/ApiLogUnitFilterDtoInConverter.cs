using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;

namespace CountyRP.Services.Logs.Converters
{
    public static class ApiLogUnitFilterDtoInConverter
    {
        public static LogUnitFilterDtoIn ToRepository(
            ApiLogUnitFilterDtoIn source
        )
        {
            return new LogUnitFilterDtoIn(
                count: source.Count,
                page: source.Page,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime,
                login: source.Login,
                ip: source.IP,
                actionId: source.ActionId.HasValue
                    ? ApiLogActionDtoConverter.ToRepository(source.ActionId.Value)
                    : null,
                text: source.Text
            );
        }
    }
}

using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiAtmFilterDtoInConverter
    {
        public static AtmFilterDtoIn ToRepository(
            ApiAtmFilterDtoIn source
        )
        {
            return new AtmFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                businessIds: source.BusinessIds
            );
        }
    }
}

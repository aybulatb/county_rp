using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    public static class ApiErrorCodeDtoConverter
    {
        public static ServiceErrorCodeDto ToService(
            ApiErrorCodeDto source
        )
        {
            return source switch
            {
                _ => ServiceErrorCodeDto.Unknown
            };
        }
    }
}
